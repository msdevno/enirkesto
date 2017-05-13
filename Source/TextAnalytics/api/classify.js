let app = require("../app");
let models = require("../models");
let languages = require("../languages")

app.post("/models/:type/classify", (req, res) => {
    /*
    Expected JSON Payload:
    {
        "key": "a unique key for the model",
        "text": "Text to classify - get tags for"
    }
    */

    let lang = languages.detect(req.body.text);
    models.getFor(req.body.key, req.params.type, lang).then(model => {
        let result = model.getClassificationsFor(req.body.text);
        res.status(200).json(result);
    });
});