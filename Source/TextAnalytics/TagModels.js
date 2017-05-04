let natural = require("natural");
let fs = require("fs");
let path = require('path');

require("./customPorterStemmerNo");

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
        return model;
    }

    loadModel(path) {
        let promise = new Promise((resolve) => 
        {
            natural.BayesClassifier.load(path, null, (err, model) => {
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
                let stemmed = combined.cleanAndStem();
                model.addDocument(stemmed, tag);
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

    getTagsFor(domain, tenant, input) {
        let promise = new Promise(resolve => {
            let stemmed = input.cleanAndStem();
            this.getFor(domain, tenant).then(model => {
                let result = model.getClassifications(stemmed);

                let modified = [];
                result.forEach(r => {
                    let valueAsString = r.value.toString();
                    let index = valueAsString.indexOf("e");
                    let score = 0;
                    if( index > 0 ) {
                        valueAsString = valueAsString.substr(0,index);
                        score = parseFloat(valueAsString);
                    } else score = r.value;
                    console.log(score);
                    
                    modified.push({
                        tag: r.label,
                        score: score
                    });
                });

                let sorted = modified.sort((a,b) => b.score - a.score);
                
                resolve(sorted);
            });
        });
        return promise;
    }
}
module.exports = TagModels;