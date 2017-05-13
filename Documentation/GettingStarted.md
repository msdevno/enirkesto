# Getting Started

## TextAnalytics host + API

The main text analytics host and its API is a [NodeJS](http://nodejs.org) project sitten in `./Source/TextAnalytics`.
You can run this and this only and already start playing around with it using the REST endpoints.

> If you haven't installed NodeJS, you can get it from [here](http://nodejs.org)

Open up a terminal and navigate to the folder. The first thing we are going to need are all the packages that we depend on installed:

```shell
$ npm install
```

> Or, if you want to use [yarn](https://yarnpkg.com/lang/en/docs/migrating-from-npm/):
> ```shell
> $ yarn install
> ```

Running it is then as simple as:

```shell
$ node .
```

It should then be showing that it is running on port 3000.
The APIs can then be accessed through `http://localhost:3000` and the route to the API.


### Train API

```http
PUT /models/:model/train
```

#### Route Parameters

| Name  | Type   | Description                     |
| ----- | ------ | ------------------------------- |
| model | string | The model type you're training. |

#### Parameters

| Name        | Type   | Description                                          |
| ----------- | ------ | ---------------------------------------------------- |
| key         | string | Unique key for a container that will hold the model. |
| language    | string | Optional language key                                |
| text        | string | Text to classify                                     |
| classifiers | array  | Array of strings holding the classifiers             |

#### Remarks

If you want to hold a general container and not a specific container. You could
then use a general key that makes it reused.

All models are stored in the `Models` folder where the key represents the sub folder within it. The filename consists of the model type combined with the language. This gives you an opportunity to have shared models, but also specific models for a particular user, tenant or similar.

The optional language key represents a [ISO 639-1](https://en.wikipedia.org/wiki/List_of_ISO_639-1_codes) code. If this is not given, the system will try to resolve the language from the text given.

#### Response

```json
Status: 200 OK
---
{}
```

#### Example

```http
PUT /models/tags/train
```

##### Payload

```json
{
    "key": "",
    "language": "",
    "text": "",
    "classifiers": ,
}
```


### Classify API

```
POST /models/:model/classify
```