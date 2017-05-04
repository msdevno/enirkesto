using Bifrost.Commands;
using Concepts.Mailbox;
using Concepts.Mailbox.Messages;

namespace Domain.Mailbox.Messages
{
    public class RemoveTag : Command
    {
        public MessageId MessageId { get; set; }
        public Tag Tag { get; set; }
    }
}