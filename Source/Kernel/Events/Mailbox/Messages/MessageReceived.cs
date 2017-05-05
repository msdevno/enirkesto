using System;
using Bifrost.Events;

namespace Events.Mailbox.Messages
{
    public class MessageReceived : Event
    {
        public MessageReceived(EventSourceId mailbox) : base(mailbox) {}

        public Guid MessageId { get; set; }
        public string Sender { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTimeOffset Received { get; set; }
    }
}