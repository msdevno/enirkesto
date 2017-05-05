let TagModels = require("./TagModels");
module.exports = {
    import: (file) => {
        let tagModels = new TagModels();
        let fs = require("fs");
        console.log("Read file");
        fs.readFile(file, "utf8", (err, data) => {
            console.log("File read");
            let json = JSON.parse(data);
            console.log(json.key);
            tagModels.putFor(json.key, json.data);
        });
    }
};