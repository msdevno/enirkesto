let natural = require("natural");
let fs = require("fs");
let path = require('path');

let models = {};

const modelsPath = "./models";

let getFileNameFor = (key) => {
    let path = `${modelsPath}/${key}/tags.json`;
    return path;
};

class TagModels {
    createModel() {
        let model = new natural.BayesClassifier();
        return model;
    }

    loadModel(path) {
        let promise = new Promise((resolve) => {
            natural.BayesClassifier.load(path, null, (err, model) => {
                resolve(model);
            });
        })

        return promise;
    }

    hasModelFor(key) {
        let path = getFileNameFor(key);
        return fs.existsSync(path);
    }

    getFor(key) {
        let promise = new Promise((resolve) => {
            if (models.hasOwnProperty(key)) {
                resolve(models[key]);
                return;
            }
            let path = getFileNameFor(key);

            if (this.hasModelFor(key)) {
                this.loadModel(path).then(resolve);
            } else {
                let model = this.createModel();
                resolve(model);
            }
        });

        return promise;
    }

    putFor(key, data) {
        let fileName = getFileNameFor(key);

        this.getFor(key).then(model => {
            let left = data.length;

            model.events.on("trainedWithDocument", () => {
                console.log(`${left} documents left`);
                left--;
            });

            console.log(`Putting in ${data.length} documents`);
            data.forEach((item) => {
                item.tags.forEach((tag) => {
                    let stemmed = item.text.cleanAndStem();
                    model.addDocument(stemmed, tag);
                })
            });
            let directory = path.dirname(fileName);
            if (!fs.existsSync(directory)) fs.mkdirSync(directory);

            console.log("Train model");
            model.train();
            models[key] = model;

            console.log("Save model");
            model.save(fileName);
            console.log("Model saved");
        });
    }

    getTagsFor(key, input) {
        let promise = new Promise(resolve => {
            let stemmed = input.cleanAndStem();
            this.getFor(key).then(model => {
                let result = model.getClassifications(stemmed);

                let modified = [];
                result.forEach(r => {
                    let valueAsString = r.value.toString();
                    let index = valueAsString.indexOf("e");
                    let score = 0;
                    if (index > 0) {
                        valueAsString = valueAsString.substr(0, index);
                        score = parseFloat(valueAsString);
                    } else score = r.value;
                    console.log(score);

                    modified.push({
                        tag: r.label,
                        score: score
                    });
                });

                let sorted = modified.sort((a, b) => b.score - a.score);

                resolve(sorted);
            });
        });
        return promise;
    }
}
module.exports = TagModels;