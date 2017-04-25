using System;
using Bifrost.Commands;
using Bifrost.Domain;
using Concepts.Messages;

namespace Domain.Messages
{
    public class MessagingCommandHandler : IHandleCommands
    {
        IAggregateRootRepository<Messaging> _mesagingRepository;

        public MessagingCommandHandler(IAggregateRootRepository<Messaging> messagingRepository)
        {
            _mesagingRepository = messagingRepository;
        }

        public void Handle(ReceiveMessage command)
        {
            var inbox = Guid.Parse("c86a7bc4-c1bf-4e3f-8190-f3550db008ec");
            var messaging = _mesagingRepository.Get(inbox);
            messaging.Receive(command.MessageId, "someone@dolittle.com", command.Subject, command.Body);
        }
    }
}