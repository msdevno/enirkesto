let app = require("./app");
let TagModels = require("./TagModels");
let tagModels = new TagModels();

app.post("/tags", (req, res) => {
    /*
    Expected JSON Payload:
    {
        "key": "a unique key for the model",
        "text": "Text to classify - get tags for"
    }
    */

    tagModels.getTagsFor(req.body.key, req.body.text).then(result => {
        res.status(200).json(result);
    });
});
