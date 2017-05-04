Bifrost.namespace("Web.Messages", {
    index: Bifrost.views.ViewModel.extend(function(messagesForCurrentUser) {
        this.messages = messagesForCurrentUser.all();

/*
        this.messages = ko.observableArray([
            {
                from: "Someone",
                Subject: "Something cool",
                when: "7 mins ago",
                starred: false,
                hasAttachment: false
            }
        ]);*/

        this.tags = ko.observableArray([
            "Spam"
        ]);
    })
});