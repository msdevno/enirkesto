using Bifrost.Events;

namespace Events.Mailbox.Messages
{
    public class TagAdded : Event
    {
        public TagAdded(EventSourceId eventSourceId) : base(eventSourceId) {}

        public string Tag { get; set; }
    }
}