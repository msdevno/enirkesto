let express = require("express");
let bodyParser = require("body-parser");
let app = express();

app.use(bodyParser.json());
module.exports = app;

app.listen(3000, () => {
    console.log("running");
});
