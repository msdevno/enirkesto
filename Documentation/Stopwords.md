# Stopwords

The [Natural Node](https://github.com/NaturalNode/natural) engine that is used has a certain amount of stop words it recognizes. You can expand on this to make it more accurate. As with [stemmers](Stemmer.md), it looks for a file mathing your language inside the "dataA folder.

In the TextAnalytics project (`./Source/TextAnalytics`), the system will look for a stop word dictionary in the `data` folder. It looks for a file called "stopwords.<language code>.txt". The language code should be a 2 letter [ISO 639-1](https://en.wikipedia.org/wiki/List_of_ISO_639-1_codes).

It is expecting one word per line in this file.

## Norwegian example

**Filename:** ./data/stopwords.nb.csv

**Content:**

```text
masse
og
i
jeg
det
at
en
et
den
```
