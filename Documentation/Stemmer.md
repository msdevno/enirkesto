# Stemmer

The point with the stemmer is to turn words into its base form, remove pluralization and such. Sometimes the algorithm used does not really do a good job with it. There is therefor support for putting in a map that maps words to its basic form for those scenarios.

In the TextAnalytics project (`./Source/TextAnalytics`), the system will look for stemmer translations / maps in the data folder. It looks for a file called "stemmer.<language code>.csv". The language code should be a 2 letter [ISO 639-1](https://en.wikipedia.org/wiki/List_of_ISO_639-1_codes).
The format within it is a CSV file using the semi-colon (;) as separator.

## Norwegian example

**Filename:** ./data/stemmer.nb.csv

**Content:**

```text
adlød;adlyde
adlydt;adlyde
anbefalt;anbefale
avstod;avstå
hagemøbler;hagemøbel
møbler;møbel
råtne;råtten
kjøpte;kjøpe
```