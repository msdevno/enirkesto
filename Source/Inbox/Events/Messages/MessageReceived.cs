using System;
using Bifrost.Events;

namespace Events.Messages
{
    public class MessageReceived : Event
    {
        public MessageReceived(EventSourceId inbox) : base(eventSourceId) {}

        public Guid MessageId { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}