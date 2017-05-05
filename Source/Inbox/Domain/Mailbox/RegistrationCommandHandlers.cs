using System;
using Bifrost.Commands;
using Bifrost.Domain;
using Concepts;

namespace Domain.Mailbox
{
    public class RegistrationCommandHandlers : IHandleCommands
    {
        IAggregateRootRepository<Registration> _repository;

        public RegistrationCommandHandlers(IAggregateRootRepository<Registration> repository)
        {
            _repository = repository;
        }

        public void Handle(AddTag command)
        {
            var userId = Guid.Parse("b02ae3d0-93fa-4f26-8e1a-46bf4210668a");
            var registration = _repository.Get(userId);
            registration.Add(command.Tag);
        }
    }
}