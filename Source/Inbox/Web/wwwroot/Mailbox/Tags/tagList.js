Bifrost.namespace("Web.Mailbox.Tags", {
    tagList: Bifrost.views.ViewModel.extend(function(addTag, tagsForCurrentUser) {
        this.addTag = addTag;

        this.tags = tagsForCurrentUser.all();
    })
});