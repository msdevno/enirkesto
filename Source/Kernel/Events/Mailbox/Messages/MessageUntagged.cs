using Bifrost.Events;

namespace Events.Mailbox.Messages
{
    public class MessageUntagged : Event
    {
        public MessageUntagged(EventSourceId eventSourceId) : base(eventSourceId) {}

        public string Tag { get; set; }
    }
}