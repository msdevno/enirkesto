using System;
using System.Threading.Tasks;
using Bifrost.Events;
using Bifrost.Read;
using Events.Mailbox.Messages;
using Read.Mailbox.Messages;

namespace TextAnalytics.Mailbox.Messages
{
    public class TaggingEventProcessors : IProcessEvents
    {
        IReadModelRepositoryFor<Message> _repository;
        RESTOperations _restOperations;

        public TaggingEventProcessors(IReadModelRepositoryFor<Message> repository, RESTOperations restOperations)
        {
            _repository = repository;
            _restOperations = restOperations;
        }

        public void Process(MessageTagged @event)
        {
            var mailbox = Guid.Parse("c86a7bc4-c1bf-4e3f-8190-f3550db008ec");
            var message = _repository.GetById(@event.EventSourceId);
            var payload = new 
            {
                key = mailbox,
                data = new[] 
                {
                    new 
                    {
                        text=$"{message.Subject} {message.Body}",
                        tags= new[] 
                        {
                            @event.Tag
                        }
                    }
                }
            };

            Task.Run(async () =>
            {
                await _restOperations.PUT("http://localhost:3000/tagmodel", payload);
            });

            // Get message by its event source ID

            // Call the REST API - training
        }

        public void Process(MessageUntagged @event)
        {
            // Get message by its event source ID

            // Call the REST API - training
        }
    }
}