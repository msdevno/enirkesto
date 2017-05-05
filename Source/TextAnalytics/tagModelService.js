let app = require("./app");
let TagModels = require("./TagModels");
let tagModels = new TagModels();

app.put("/tagmodel", (req, res) => {
    /*
    Expected JSON Payload:
    {
        "key": "a unique key for the model",
        "data": [
            {
                "text": "",
                "tags": ["",""]
            },
            {
                "text": "",
                "tags": ["",""]
            }
        ]
    }
    */
    
    tagModels.putFor(req.body.key, req.body.data);
    res.status(200).json({});
});