let fs = require("fs");
let path = require("path");
let lineReader = require("./lineReader");

const root_folder = "./data";

const _language = new WeakMap();

class Stopwords {
    constructor(language) {
        this.words = [];
        _language.set(this, language);
    }

    get language() {
        return _language.get(this);
    }

    prepare() {
        let language = _language.get(this);
        let self = this;
        let promise = new Promise((resolve) => {
            let file = path.join(process.cwd(), `${root_folder}/stopwords.${language}.txt`);
            if (fs.existsSync(file)) {
                lineReader(file, word => self.words.push(word.trim())).then(() => resolve());
            }
        });
        return promise;
    }
}

let stopwordsPerLanguage = {};

module.exports = {
    getFor: (language) => {
        let promise = new Promise(resolve => {
            if (stopwordsPerLanguage.hasOwnProperty(language)) {
                resolve(stopwordsPerLanguage[language]);
            } else {
                var stopwords = new Stopwords(language)
                stopwordsPerLanguage[language] = stopwords;
                stopwords.prepare().then(() => resolve(stopwords));
            }
        });
        return promise;
    }
}
