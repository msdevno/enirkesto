let fs = require("fs");
let readLine = require("readline");

module.exports = (file, lineCallback) => {
    let promise = new Promise(resolve => {
        let reader = readLine.createInterface({
            input: fs.createReadStream(file),
            output: process.stdout,
            console: false
        });

        reader.on("line", (line) => {
            lineCallback(line);
        });

        reader.on("close", () => {
            resolve();
        });

    });
    return promise;
};