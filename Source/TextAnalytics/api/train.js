let app = require("../app");
let models = require("../models");

app.put("/models/:type/train", (req, res) => {
    /*
    Expected JSON Payload:
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

    models.getFor(req.body.key, req.params.type, req.body.language).then(model => {
        req.body.data.forEach(item => {
            model.addClassificationsFor(item.text, item.classifiers);
        });

        model.retrain();
    });
    res.status(200).json({});
});