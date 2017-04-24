using Bifrost.Events;

namespace Events.Messages
{
    public class TagRemoved : Event
    {
        public TagRemoved(EventSourceId eventSourceId) : base(eventSourceId) {}

        public string Tag { get; set; }
    }
}