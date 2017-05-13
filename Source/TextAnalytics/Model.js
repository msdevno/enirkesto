let stemmers = require("./stemmers");
let natural = require("natural");
let path = require("path");
let fs = require("fs");
let mkdirp = require("mkdirp");

const _key = new WeakMap();
const _type = new WeakMap();
const _language = new WeakMap();
const _model = new WeakMap();
const _stemmer = new WeakMap();

const modelsPath = "./models";

class Model {
    constructor(key, type, language) {
        _key.set(this, key);
        _type.set(this, type);
        _language.set(this, language);
    }

    get key() {
        return _key.get(this);
    }

    get type() {
        return _type.get(this);
    }

    get language() {
        return _language.get(this);
    }

    get stemmer() {
        return _stemmer.get(this);
    }

    get model() {
        return _model.get(this);
    }

    prepare() {
        let self = this;

        let promise = new Promise((resolve) => {
            let promises = [];

            promises.push(stemmers.getFor(self.language));

            let filename = getFileNameFor(self.key, self.type, self.language);
            if (fs.existsSync(filename)) {
                promises.push(loadModel(filename));
            } else {
                _model.set(self, createModel());
            }

            Promise.all(promises).then(results => {
                _stemmer.set(self, results[0]);
                if (results.length == 2) {
                    _model.set(self, results[1]);
                }
                resolve();
            });
        });
        return promise;
    }

    getClassificationsFor(input) {
        let stemmed = _stemmer.get(this).tokenizeAndStem(input);
        let result = _model.get(this).getClassifications(stemmed);
        let sorted = sort(result);
        return sorted;
    }

    addClassificationsFor(input, classifications) {
        let self = this;
        let stemmed = _stemmer.get(this).tokenizeAndStem(input);

        classifications.forEach(classification => {
            self.model.addDocument(stemmed, classification);
        });
    }

    retrain() {
        this.model.retrain();
        let folder = getFolderFor(this.key);
        let filename = getFileNameFor(this.key, this.type, this.language);

        mkdirp(folder, () => {
            this.model.save(filename);
        });
    }
}

let getFolderFor = (key) => {
    let folder = path.join(process.cwd(), `${modelsPath}/${key}`);
    return folder;
};

let getFileNameFor = (key, type, language) => {
    let file = `${getFolderFor(key)}/tags.${language}.json`;
    return file;
};

let createModel = () => {
    let model = new natural.BayesClassifier();
    return model;
};

let loadModel = (path) => {
    let promise = new Promise((resolve) => {
        natural.BayesClassifier.load(path, null, (err, model) => {
            resolve(model);
        });
    })

    return promise;
};

let sort = (input) => {
    let modified = [];
    input.forEach(r => {
        let valueAsString = r.value.toString();
        let index = valueAsString.indexOf("e");
        let score = 0;
        if (index > 0) {
            valueAsString = valueAsString.substr(0, index);
            score = parseFloat(valueAsString);
        } else score = r.value;

        modified.push({
            tag: r.label,
            score: score
        });
    });

    let sorted = modified.sort((a, b) => b.score - a.score);
    return sorted;
};


module.exports = Model;