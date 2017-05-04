using System;
using Bifrost.Domain;
using Bifrost.Events;
using Concepts.Mailbox.Messages;
using Events.Mailbox.Messages;

namespace Domain.Mailbox.Messages
{
    public class Messaging : AggregateRoot
    {
        public Messaging(EventSourceId inbox) : base(inbox) {}

        public void Receive(MessageId messageId, Sender sender, Subject subject, Body body)
        {
            Apply(new MessageReceived(EventSourceId)
            {
                MessageId = messageId,
                Sender = sender,
                Subject = subject,
                Body = body,
                Received = DateTimeOffset.UtcNow
            });
        }
    }
}