let natural = require("natural");
let stopwords = require("./stopwords");
let lineReader = require("./lineReader");
let path = require("path");
let fs = require("fs");

const root_folder = "./data";

const _language = new WeakMap();
const _actualStemmer = new WeakMap();
const _stopwords = new WeakMap();

class Stemmer {
    constructor(language) {
        _language.set(this, language);
        this.dictionary = {};

        let actualStemmer = natural.PorterStemmerNo;
        _actualStemmer.set(this, actualStemmer);
        actualStemmer._originalStem = actualStemmer.stem;
        actualStemmer.stem = this.stem;
        actualStemmer.stemByDictionary = (token) => this.stemByDictionary(token);
    }

    get language() {
        return _language.get(this);
    }

    load() {
        let self = this;
        let promise = new Promise(resolve => {
            let file = path.join(process.cwd(), `${root_folder}/stemmer.${self.language}.csv`);
            if (!fs.existsSync(file)) {
                resolve();
            } else {
                lineReader(file, (line) => {
                    let words = line.split(";");
                    self.dictionary[words[0].trim()] = words[1].trim();
                }).then(() => resolve());
            }
        });
        return promise;
    }

    prepare() {
        let self = this;
        let promise = new Promise(resolve => {
            let promises = [];

            promises.push(stopwords.getFor(self.language));
            promises.push(self.load());

            Promise.all(promises).then(results => {
                _stopwords.set(self, results[0]);
                results[0].words.forEach(_actualStemmer.get(this).addStopWord);
                resolve();
            });
        });
        return promise;
    }

    stemByDictionary(token) {
        if (this.dictionary.hasOwnProperty(token)) return this.dictionary[token];
        return token;
    }

    stem(token) {
        let tokenLowerCase = token.toLowerCase();
        let stemmedByDictionary = this.stemByDictionary(tokenLowerCase);
        if (stemmedByDictionary != token) return stemmedByDictionary;
        let stemmed = this._originalStem(token);
        return this.stemByDictionary(stemmed);
    }

    tokenizeAndStem(input, keepStops) {
        keepStops = keepStops || false;
        let stemmedTokens = _actualStemmer.get(this).tokenizeAndStem(input, keepStops);
        let stemmedInput = stemmedTokens.join(" ");
        return stemmedInput;
    }
}

let stemmers = {};

module.exports = {
    getFor: (language) => {
        let promise = new Promise((resolve) => {
            if (stemmers.hasOwnProperty(language)) {
                resolve(stemmers[language]);
            } else {
                let stemmer = new Stemmer(language);
                stemmers[language] = stemmer;
                stemmer.prepare().then(() => {
                    resolve(stemmer);
                });
            }
        });
        return promise;
    }
}

