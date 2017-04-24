let express = require("express");
let bodyParser = require("body-parser");
let app = express();



let TagModels = require("./TagModels");
let tagModels = new TagModels();
let fs = require("fs");
console.log("Read file");
fs.readFile("./kid.txt", "utf8", (err, data) => {
    console.log("File read");
    let json = JSON.parse(data);
    tagModels.putFor(json.domain, json.tenant, json.data);
});


app.use(bodyParser.json());

module.exports = app;

