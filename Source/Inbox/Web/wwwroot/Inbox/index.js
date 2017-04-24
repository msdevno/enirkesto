Bifrost.namespace("Web.Inbox", {
    index: Bifrost.views.ViewModel.extend(function() {
        this.messages = ko.observableArray([
            {}
        ]);

        this.tags = ko.observableArray([
            {}
        ]);
    })
});