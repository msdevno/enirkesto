let app = require("../app");
let models = require("../models");
let languages = require("../languages")

app.put("/models/:type/train", (req, res) => {
    /*
    Expected JSON Payload:
    {
        "key": "a unique key for the model",
        "language": "optional - if not present, we'll try to detect it. iso639 - 2 letter representation e.g. nb for Norwegian Bokmål"
        "text": "",
        "classifiers": ["",""]
    }
    */
    let lang = req.body.language || languages.detect(req.body.text);
    models.getFor(req.body.key, req.params.type, lang).then(model => {
        model.addClassificationsFor(req.body.text, req.body.classifiers);
        model.retrain();
    });
    res.status(200).json({});
});