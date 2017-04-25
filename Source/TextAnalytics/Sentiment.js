let natural = require("natural");

class Sentiment
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
}