let TagModels = require("./TagModels");
module.exports = {
    import: (file) => {
        let tagModels = new TagModels();
        let fs = require("fs");
        console.log("Read file");
        fs.readFile(file, "utf8", (err, data) => {
            console.log("File read");
            let json = JSON.parse(data);
            tagModels.putFor(json.domain, json.tenant, json.data);
        });
    }
};