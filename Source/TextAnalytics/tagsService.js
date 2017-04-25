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

    let messageToClassify = `${req.body.subject} ${req.body.message}`;
    tagModels.getTagsFor(req.body.domain, req.body.tenant, messageToClassify).then(result => {
        res.status(200).json(result);
    });
});
