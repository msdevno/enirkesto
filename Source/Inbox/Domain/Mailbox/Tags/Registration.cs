using Concepts;
using Concepts.Mailbox;
using Bifrost.Domain;
using Bifrost.Events;
using Events.Mailbox.Tags;


namespace Domain.Mailbox.Tags
{
    public class Registration : AggregateRoot
    {
        public Registration(EventSourceId eventSourceId) : base(eventSourceId) {}

        public void Add(User user, Tag tag)
        {
            Apply(new TagAdded(EventSourceId) {
                User = user,
                Tag = tag
            });
        }
    }
}