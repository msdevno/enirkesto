let models = require("./models");
module.exports = {
    import: (file) => {
        /*
        Expected file format:
        {
            "key": "a unique key for the model",
            "language": "iso639 - 2 letter representation e.g. nb for Norwegian Bokmål",
            "data": [
                {
                    "text": "",
                    "classifiers": ["",""]
                },

                {
                    "text": "",
                    "classifiers": ["",""]
                }
            ]
        }
        */
        
        let fs = require("fs");
        console.log("Read file");
        fs.readFile(file, "utf8", (err, data) => {
            console.log("File read");
            let json = JSON.parse(data);
            models.getFor(json.key, json.type, json.language).then(model => {
                json.data.forEach(item => {
                    model.addClassificationsFor(item.text, item.classifiers);
                });
                model.train();
            });
        });
    }
};