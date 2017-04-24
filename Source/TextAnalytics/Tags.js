let app = require("./app");
let TagModels = require("./TagModels");

const basePath = "tags";

class Tags
{
    constructor() {
        let self = this;
        this.tagModels = new TagModels();

        app.put("/tags/model", (req, res) => {
            self.tagModels.putFor(req.body.domain, req.body.tenant, req.body.data);
            res.status(200).json({});
        });

        app.post("/tags", (req, res) => {
            
            /*
            {
                "domain": "banking", // retail // general
                "tenant": "", // optional
                "subject": "",
                "message": ""
            }
            */
            self.tagModels.getFor(req.body.domain, req.body.tenant).then(model => {
                let messageToClassify = `${req.body.subject} ${req.body.message}`;
                let result = model.getClassifications(messageToClassify);
                res.status(200).json(result);
            });
        });
        //app.put(`${basePath}/model`, (req, res) => this.set(JSON.parse(req.)));
    }
}

module.exports = Tags;

//app.post("/categories/data", (req, res) => {
    // JSON Payload
    /*
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
    //res.end(200);
//});

/*
app.get("/categories", (req, res) => {
    let result = classifier.getClassifications(req.query.message);
    //let tokenizer = new natural.WordTokenizer();
    //tokenizer.tokenize(req.query.message);

    res.write(JSON.stringify(result));
    res.end(200);
});*/
