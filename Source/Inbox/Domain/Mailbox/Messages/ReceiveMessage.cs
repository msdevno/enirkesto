using Bifrost.Commands;
using Concepts.Mailbox.Messages;

namespace Domain.Mailbox.Messages
{
    public class ReceiveMessage : Command
    {
        public MessageId MessageId { get; set; }
        public Subject Subject { get; set; }
        public Body Body { get; set; }
    }
}