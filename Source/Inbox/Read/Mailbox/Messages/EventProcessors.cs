using System;
using Bifrost.Events;
using Bifrost.Read;
using Events.Mailbox.Messages;

namespace Read.Mailbox.Messages
{
    public class EventProcessors : IProcessEvents
    {
        IReadModelRepositoryFor<Message> _messageRepository;
        public EventProcessors(IReadModelRepositoryFor<Message> messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public void Process(MessageReceived @event)
        {
            var message = new Message
            {
                Inbox = (Guid)@event.EventSourceId,
                MessageId = @event.MessageId,
                Subject = @event.Subject,
                Body = @event.Body,
                Received = @event.Received
            };

            _messageRepository.Insert(message);
        }
    }
}