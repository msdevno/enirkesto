Bifrost.namespace("Web.Messages", {
    index: Bifrost.views.ViewModel.extend(function() {
        this.messages = ko.observableArray([
            {
                from: "Someone",
                Subject: "Something cool",
                when: "7 mins ago",
                starred: false,
                hasAttachment: false
            }
        ]);

        this.tags = ko.observableArray([
            "Spam"
        ]);
    })
});