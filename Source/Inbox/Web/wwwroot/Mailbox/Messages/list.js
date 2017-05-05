Bifrost.namespace("Web.Mailbox.Messages", {
    list: Bifrost.views.ViewModel.extend(function(messagesForCurrentUser, tagsForCurrentUser, tagMessage, untagMessage) {
        this.messages = messagesForCurrentUser.all();
        this.tags = tagsForCurrentUser.all();

        this.toggleTag = function(message, tag) {
            tagMessage.messageId(message.messageId);
            tagMessage.tag(tag.name);
            tagMessage.execute();
        };
    })
});