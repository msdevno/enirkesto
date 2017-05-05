using System;
using System.Linq;
using Bifrost.Events;
using Bifrost.Read;
using Concepts.Mailbox;
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

        public void Process(MessageTagged @event)
        {
            var message = _messageRepository.GetById(@event.EventSourceId);
            if( !message.Tags.AsQueryable().Contains((TagName)@event.Tag) ) 
            {
                message.Tags = message.Tags.AsQueryable().Concat(new TagName[] { (TagName)@event.Tag }).ToArray();
                _messageRepository.Update(message);
            }
        }
    }
}