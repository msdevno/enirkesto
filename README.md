# Enirkesto

This project was made in collaboration with a partner; [SocialBoards](http://socialboards.com) from the need of text analytics in Norwegian. With [Microsoft Cognitive Services](https://www.microsoft.com/cognitive-services) not having support for Norwegian for what the partner needed at the time of doing this project (April / May of 2017). [SocialBoards](http://socialboards.com) delivers a unified support inbox aggregated from multiple channels, amongst these social channels such as [Twitter](https://twitter.com), [Facebook](https://facebook.com), [Instagram](https://instagram.com) and more. Enirkesto is basically Inbox in [Esperanto](https://en.wikipedia.org/wiki/Esperanto) and is as close as we can go in an open source project to the
core business of what [SocialBoards](http://socialboards.com) delivers.

## Goals

The primary goals of this project is to enable the business scenarios for the partner, which can be broken down into tagging of messages and sentiment analysis. You can read about the conclusion of how we ended up doing text analytics [here](Documentation/TextAnalytics.md).

### Architectural

In addition to the core business goals as mentioned above we also wanted to establish good architectural patterns around the project. By leveraging the concepts behind [Domain Driven Design](https://en.wikipedia.org/wiki/Domain-driven_design), [CQRS](https://docs.microsoft.com/en-us/azure/architecture/patterns/cqrs) and [Event Sourcing](https://docs.microsoft.com/en-us/azure/architecture/patterns/event-sourcing) we build in a modern, cloud ready fashion - focusing on the core business domain. The project leverages [Bifrost](http://www.dolittle.io/bifrost) (soon to moved and called [dolittle](http://www.dolittle.io)); a platform enabling you to be focused on the domain and offering the building blocks for CQRS and Event Sourcing. Read more about the architecture [here](Documentation/Architecture.md).

## Getting started

To get started with the code, you will need [NodeJS](https://nodejs.org/en/) and [.NET Core](https://www.microsoft.com/net/download/core) installed. The solution has been developed using [Visual Studio Code](https://code.visualstudio.com), but you can use your existing environment as well. The .NET part should also be fine to open in [Visual Studio 2017](https://www.visualstudio.com/vs/).

Some of the projects are shared, these are expected to be symbolically linked into the projects that need them. Before you open up any of the projects you therefor have to run the appropriate setup script for your platform to enable this [setup.sh](setup.sh) (Mac / Linux) and [setup.cmd](setup.cmd) (Windows). More details on the different projects can be found [here](Documentation/Projects.md).



### Docker containers

A full running version of every part of the system are available as Docker containers [here](https://hub.docker.com/u/enirkesto/).
If you haven't already got Docker installed - here is how you get started on [Mac](https://docs.docker.com/docker-for-mac/), [Linux](https://docs.docker.com/engine/installation/linux/), [Windows](https://docs.docker.com/docker-for-windows/).
You can run everything by navigating with your terminal / console to the root of this project and enter the following:

```shell
$ docker-compose up
```

If you want to build everything from scratch and get the Docker images locally from your own local repository, you can run the [build.sh](build.sh) / [build.cmd](build.cmd) script. Mind that the images will targetting the [enirkesto](https://hub.docker.com/u/enirkesto/) organization, but you can of course change that inside the scripts.
