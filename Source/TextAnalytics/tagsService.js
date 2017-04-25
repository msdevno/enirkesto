let app = require("./app");
let TagModels = require("./TagModels");
let tagModels = new TagModels();

app.post("/tags", (req, res) => {
    /*
    Expected JSON Payload:
    {
        "domain": "banking", // retail // general
        "tenant": "", // optional
        "subject": "",
        "message": ""
    }
    */
    tagModels.getFor(req.body.domain, req.body.tenant).then(model => {
        let messageToClassify = `${req.body.subject} ${req.body.message}`;
        let result = model.getClassifications(messageToClassify);
        res.status(200).json(result);
    });
});
