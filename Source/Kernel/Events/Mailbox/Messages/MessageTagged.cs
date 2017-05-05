using Bifrost.Events;

namespace Events.Mailbox.Messages
{
    public class MessageTagged : Event
    {
        public MessageTagged(EventSourceId eventSourceId) : base(eventSourceId) {}

        public string Tag { get; set; }
    }
}