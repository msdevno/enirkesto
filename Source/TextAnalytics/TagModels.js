let natural = require("natural");
let fs = require("fs");
let path = require('path');

let models = {};

const modelsPath = "./models";

let getKeyFor = (domain, tenant) => {
    if( !tenant || tenant.length == 0) return domain;
    let key = `${domain}_${tenant}`;
    return key;
}

let getFileNameFor = (domain, tenant) => {
    let key = getKeyFor(domain,tenant);
    let path = `${modelsPath}/${key}/tags.json`;
    return path;
};

class TagModels
{
    createModel() {
        let model = new natural.BayesClassifier();
        //let model = new natural.LogisticRegressionClassifier();
        return model;
    }

    loadModel(path) {
        let promise = new Promise((resolve) => 
        {
            natural.BayesClassifier.load(path, null, (err, model) => {
            //natural.LogisticRegressionClassifier.load(path, null, (err, model) => {
                resolve(model);
            });       
        })

        return promise;
    }

    hasModelFor(domain, tenant) {
        let path = getFileNameFor(domain,tenant);
        return fs.existsSync(path);
    }

    getFor(domain, tenant) {
        let promise = new Promise((resolve)=> {
            let key = getKeyFor(domain,tenant);
            if( models.hasOwnProperty(key)) return models[key];
            let path = getFileNameFor(domain,tenant);

            if( this.hasModelFor(domain,tenant) ) {
                this.loadModel(path).then(resolve);
            } else {
                let model = this.createModel();
                resolve(model);
            }
        });

        return promise;
    }

    putFor(domain, tenant, data) {
        let key = getKeyFor(domain,tenant);
        let fileName = getFileNameFor(domain,tenant);

        let model = this.createModel();
        
        let left = data.length;

        model.events.on("trainedWithDocument", (obj) => {
            console.log(`${left} documents left`);
            left--;
        });

        console.log(`Putting in ${data.length} documents`);
        data.forEach((item) => {
            item.tags.forEach((tag) => {
                let combined = `${item.subject} ${item.message}`;
                model.addDocument(combined, tag);
            })
        });
        let directory = path.dirname(fileName);
        if( !fs.existsSync(directory) ) fs.mkdirSync(directory);

        console.log("Train model");
        model.train();
        models[key] = model;

        console.log("Save model");
        model.save(fileName);
        console.log("Model saved");
    }
}
module.exports = TagModels;