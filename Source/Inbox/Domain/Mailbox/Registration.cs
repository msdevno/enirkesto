using Concepts;
using Concepts.Mailbox;
using Bifrost.Domain;
using Bifrost.Events;
using Events.Mailbox;

namespace Domain.Mailbox
{
    public class Registration : AggregateRoot
    {
        public Registration(EventSourceId eventSourceId) : base(eventSourceId) {}

        public void Add(TagName tagName)
        {
            Apply(new TagAdded(EventSourceId) {
                Name = tagName
            });
        }
    }
}