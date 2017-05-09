let Model = require("./Model");

let models = {};

let getKeyFor = (key, type, language) => {
    return `${key}-${type}-${language}`;
};

module.exports = {
    getFor: (key, type, language) => {
        let promise = new Promise((resolve) => {
            let modelKey = getKeyFor(key, type, language);
            if (models.hasOwnProperty(modelKey)) {
                resolve(models[modelKey]);
            } else {
                var model = new Model(key, type, language);
                models[modelKey] = model;
                model.prepare().then(() => resolve(model));
            }
        });
        return promise;
    }
}