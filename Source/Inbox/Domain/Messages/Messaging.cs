using Bifrost.Domain;
using Bifrost.Events;
using Concepts.Messages;
using Events.Messages;

namespace Domain.Messages
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
                Body = body
            });
        }
    }
}