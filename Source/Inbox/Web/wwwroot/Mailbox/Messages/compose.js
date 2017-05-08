Bifrost.namespace("Web.Mailbox.Messages", {
    compose: Bifrost.views.ViewModel.extend(function(receiveMessage) {
        this.receiveMessage = receiveMessage;
    })
})