using System;
using System.Linq;
using Bifrost.Read;

namespace Read.Mailbox.Messages
{
    public class MessagesForCurrentUser : IQueryFor<Message>
    {
        IReadModelRepositoryFor<Message> _messageRepository;

        public MessagesForCurrentUser(IReadModelRepositoryFor<Message> messageRepository)
        {
            _messageRepository = messageRepository;
        }


        public IQueryable<Message> Query =>  _messageRepository.Query; //.Where(m => m.Inbox == Guid.Parse("c86a7bc4-c1bf-4e3f-8190-f3550db008ec"));
    }
}