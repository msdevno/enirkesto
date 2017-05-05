using System;
using Bifrost.Events;
using Bifrost.Read;
using Events.Mailbox;

namespace Read.Mailbox
{
    public class TagEventProcessors : IProcessEvents
    {
        IReadModelRepositoryFor<Tag> _repository;
        public TagEventProcessors(IReadModelRepositoryFor<Tag> repository)
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