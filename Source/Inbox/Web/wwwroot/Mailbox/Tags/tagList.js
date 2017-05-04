Bifrost.namespace("Web.Mailbox.Tags", {
    tagList: Bifrost.views.ViewModel.extend(function() {
        this.tags = ko.observableArray([
            "Spam"
        ]);
    })
});