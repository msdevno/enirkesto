Bifrost.namespace("Web.Mailbox.Messages", {
    list: Bifrost.views.ViewModel.extend(function(messagesForCurrentUser, addTag) {
        this.messages = messagesForCurrentUser.all();

        this.toggleTag = function(message, tag) {

        };
    })
});