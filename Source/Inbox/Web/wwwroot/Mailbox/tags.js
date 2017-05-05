Bifrost.namespace("Web.Mailbox", {
    tags: Bifrost.views.ViewModel.extend(function(addTag, tagsForCurrentUser) {
        this.addTag = addTag;

        this.tags = tagsForCurrentUser.all();
    })
});