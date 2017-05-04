using System;
using Bifrost.Commands;
using Bifrost.Domain;

namespace Domain.Mailbox.Messages
{
    public class TaggingCommandHandlers : IHandleCommands
    {
        IAggregateRootRepository<Tagging> _taggingRepository;

        public TaggingCommandHandlers(IAggregateRootRepository<Tagging> taggingRepository)
        {
            _taggingRepository = taggingRepository;
        }

        public void Handle(AddTag command)
        {
            var tagging = _taggingRepository.Get((Guid)command.MessageId);
            tagging.Add(command.Tag);
        }

        public void Handle(RemoveTag command)
        {
            var tagging = _taggingRepository.Get((Guid)command.MessageId);
            tagging.Remove(command.Tag);
        }
    }
}