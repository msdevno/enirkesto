# Functionality

In the application there are different functionality. This document describes the most relevant ones and how they are used and how they flow through the system.

## Adding tags

The first thing one needs to start off with is to actually add tags into the system. Otherwise there is nothing to tag messages coming in with. The tags are unique per users mailbox.

Enter the tag name in the "Tagname" input:

![Enter Tag](images/EnterTag.png)

Then click the plus button:

![Enter Tag](images/InsertTag.png)


## Compose Message

To train the text analytics model, we will have to start tagging messages. In order to create a message that will be possible to tag, you can navigate to the compose page:

![Navigate to compose](images/ComposeNavigation.png)

Fill out all the fields and then click send.

![Compose and send message](images/ComposeMessage.png)

Navigate back to the reading list:

![Navigate to read](images/ReadNavigation.png)


## Tagging messages

From the inbox list you will be able to see the message you put in and be able to tag it.

![Tag Message](images/TagMessage.png)



## Receiving messages

The goal when receiving messages is to be able to automatically tag them according to the trained model. The Flow below describes the steps it goes through with the [architecture](Architecture.md) its based on.

![Message Ingress Flow](images/Message_Ingress_Flow.png)

## Tagging

In the UI

![Message Ingress Flow](images/Message_Tagging_Flow.png)