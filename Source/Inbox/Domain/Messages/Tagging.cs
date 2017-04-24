using Bifrost.Domain;
using Bifrost.Events;
using Concepts.Messages;
using Events.Messages;

namespace Domain.Messages
{
    public class Tagging : AggregateRoot
    {
        public Tagging(EventSourceId eventSourceId) : base(eventSourceId) {}

        public void Add(Tag tag)
        {
            Apply(new TagAdded(EventSourceId) { Tag = tag });
        }

        public void Remove(Tag tag)
        {
            Apply(new TagRemoved(EventSourceId) { Tag = tag });
        }
    }
}