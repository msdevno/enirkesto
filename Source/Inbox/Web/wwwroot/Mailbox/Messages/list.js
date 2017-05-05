Bifrost.namespace("Web.Mailbox.Messages", {
    list: Bifrost.views.ViewModel.extend(function(messagesForCurrentUser, addTag, tagsForCurrentUser) {
        this.messages = messagesForCurrentUser.all();
        this.tags = tagsForCurrentUser.all();

        this.toggleTag = function(message, tag) {

        };
    })
});