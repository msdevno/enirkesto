let app = require("./app");
let TagModels = require("./TagModels");
let tagModels = new TagModels();

app.put("/tagmodel", (req, res) => {
    /*
    Expected JSON Payload:
    {
        "domain": "banking", // retail // general
        "tenant": "", // optional
        "data": [
            {
                "subject": "",
                "message": "",
                "tags": ["",""]
            },
            {
                "subject": "",
                "message": "",
                "tags": ["",""]
            }
        ]
    }
    */
    
    tagModels.putFor(req.body.domain, req.body.tenant, req.body.data);
    res.status(200).json({});
});