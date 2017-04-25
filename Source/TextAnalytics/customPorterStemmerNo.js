let natural = require("natural");

let dictionary = {};

natural.PorterStemmerNo.attach();
let originalStem = natural.PorterStemmerNo.stem;

natural.PorterStemmerNo.stemByDictionary = (token) => {
    if( dictionary.hasOwnProperty(token) ) return dictionary[token];
    return token;
};

natural.PorterStemmerNo.stem = (token) => {
    let tokenLowerCase = token.toLowerCase();
    let stemmedByDictionary = natural.PorterStemmerNo.stemByDictionary(tokenLowerCase);
    if( stemmedByDictionary != token ) return stemmedByDictionary;
    let stemmed = originalStem(token);
    return natural.PorterStemmerNo.stemByDictionary(stemmed);
};

let lineReader = require("./lineReader");
let promises = [];

promises.push(lineReader("./dictionary.csv", (line) => {
    let words = line.split(";");
    dictionary[words[0].trim()] = words[1].trim();
}));

promises.push(lineReader("./stopwords.txt", (word) => {
    natural.PorterStemmerNo.addStopWord(word.trim());
}));

String.prototype.cleanAndStem = function(keepStops) {
    keepStops = keepStops || false;
    let stemmedTokens = natural.PorterStemmerNo.tokenizeAndStem(this, keepStops);
    let stemmedInput = stemmedTokens.join(" ");
    return stemmedInput;
};