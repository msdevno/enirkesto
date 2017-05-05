using Bifrost.Domain;
using Bifrost.Events;
using Concepts.Mailbox;
using Concepts.Mailbox.Messages;
using Events.Mailbox.Messages;

namespace Domain.Mailbox.Messages
{
    public class Tagging : AggregateRoot
    {
        public Tagging(EventSourceId eventSourceId) : base(eventSourceId) {}

        public void Add(TagName tag)
        {
            Apply(new TagAdded(EventSourceId) { Tag = tag });
        }

        public void Remove(TagName tag)
        {
            Apply(new TagRemoved(EventSourceId) { Tag = tag });
        }
    }
}