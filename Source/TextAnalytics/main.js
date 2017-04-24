//let natural = require("natural");
let app = require("./app");
let Tags = require("./Tags");

let tags = new Tags();

/*
let classifier = new natural.BayesClassifier();
classifier.addDocument("Jeg liker godt Kesam", "Kesam");
classifier.addDocument("Jeg liker godt Kesam", "Yoghurt");
classifier.addDocument("Katter ville velge Whizkas", "Kattemat");
classifier.train();*/

// API


app.listen(3000, () => {
    console.log("running");
});
