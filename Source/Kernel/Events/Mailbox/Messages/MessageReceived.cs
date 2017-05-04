using System;
using Bifrost.Events;

namespace Events.Mailbox.Messages
{
    public class MessageReceived : Event
    {
        public MessageReceived(EventSourceId inbox) : base(inbox) {}

        public Guid MessageId { get; set; }
        public string Sender { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTimeOffset Received { get; set; }
    }
}