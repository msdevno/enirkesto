Bifrost.namespace("Web.Mailbox.Tags", {
    tagList: Bifrost.views.ViewModel.extend(function(addTag) {
        this.addTag = addTag;

        this.tags = ko.observableArray([
            "Spam"
        ]);
    })
});