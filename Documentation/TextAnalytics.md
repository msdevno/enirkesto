# Text Analytics

The Text Analytics section of Enirkesto, is divided into two parts.
The first part consists of tagging, and the second of sentiment analysis.
Many of the same concepts are used throughout both of the segments.
The core engine leverages the [Natural framework](https://github.com/NaturalNode/natural) for both tagging and sentiment.

`Tagging (extracting the gist of the text)`
`Sentiment (extracting the feeling and attitude of the text)`

## The process (tagging)

Keyword extraction is tasked with the automatic identification of terms that best describe the subject of a document. This is referred to as “tagging” in Enirkesto.

### Tokenization

The first technique used from the Natural-framework, is the “tokenization” capability.
This allows Enirkesto to split some given text into smaller tokens, this could be words, phrases or whole sentences. The implementation in Enirkest tokenizes the document into single words.

For sentiment, the next natural path to follow, would be to implement the “Bag of words” model. In order to do this, we simply count the number of times each word shows up. This is not performed during the Tagging phase of Enirkesto. The reason for this is simply because Enirkesto does not use the Lexicon-based approach of checking the subjectivity of each word from an existing lexicon (a database of emotional values for words prerecorded by researchers). If this procedure was conducted, the overall subjectivity of the text could be computed for a sentiment approach (which is not yet implemented in Enirkesto – but might be in future updates).

The other approach for sentiment, would be to use machine learning to train a classifier on already existing data points – this approach might also be supported in future updates.

There are pros and cons for both approaches mentioned above. Using a lexicon is easier, but the machine learning approach is more accurate and should get more and more accurate over time if retraining is conducted. Subtleties in language that the lexicon approach would suffer from, could for instance be sarcasm. Deep neural net on the other hand could understand the subtleties because they don’t analyze text at face value, but rather create abstract representations of what it learned. These generalizations are called vectors and we could potentially use these to classify data

The engine also converts the tokens into lowercase for normalization purposes.

### Stemming

After the tokenization has been conducted, the next technique Enirkesto leverages, is the “stemming” capability from the Natural-framework. In linguistic morphology and information retrieval, Stemming is the process of reducing a word into its stem, i.e. its root form. The root form is not necessarily a word by itself, but it can be used to generate words by concatenating the right suffix. An example could be “Fishes”, or “Fished” into; “Fish”. A popular stemmer is called the Porter stemmer and was first introduced in the 1980’s. This is currently used in the Enirkesto engine. The cool thing about Enirkesto, is that it uses a combination of the Porter Stemmer and a dictionary with words. This can be extended for whatever language you prefer. If the word doesn’t exist in the dictionary, the stemming engine does its best to reduce the word into its stem. However, if the word is present in the dictionary, the engine will use the proper root form that is stated within the dictionary.

### Stop words

Enirkesto also uses a technique to split text into important and unimportant words. All of the unimportant words that are present in the text, will be removed since it will bring no real value to the classifier. This technique is called “removing stop words”. The list of stop words can be extended to whatever language, and can easily be used by importing your own txt-file.

At this point, Enirkesto has what it needs in the right format in order to train a classifier to classify the right tags for an input text (this could be a post/message/enquiry etc.). In the Natural-framework; two classifiers were supported. Naïve Bayes and Logistic Regression. Enirkesto uses Naive Bayes, but can easily be substituted for Logistic Regression.

After the classifier has been trained with the appropriate data, a model arises which is persisted. This model will be used to further classify new data. Majority of the project uses Norwegian as the base language, but can easily be changed to whatever language you prefer.

Based on the request, the Naive Bayes classifier will generate a set of tags (classes classified) with its corresponding probability score.
