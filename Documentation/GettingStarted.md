# Getting Started

## TextAnalytics host

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

Read more about the APIs [here](TextAnalyticsAPI.md). For how it actually works internalls, you can get more details [here](TextAnalytics.md).