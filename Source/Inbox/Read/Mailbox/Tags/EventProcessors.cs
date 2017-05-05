using System;
using Bifrost.Events;
using Bifrost.Read;
using Events.Mailbox.Tags;

namespace Read.Mailbox.Tags
{
    public class EventProcessors : IProcessEvents
    {
        IReadModelRepositoryFor<Tag> _repository;
        public EventProcessors(IReadModelRepositoryFor<Tag> repository)
        {
            _repository = repository;
        }

        public void Process(TagAdded @event)
        {
            _repository.Insert(new Tag 
            {
                TagId = Guid.NewGuid(),
                User = (Guid)@event.EventSourceId,
                Name = @event.Name
            });
            
        }
    }
}