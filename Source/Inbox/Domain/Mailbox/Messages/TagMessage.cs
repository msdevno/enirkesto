using Bifrost.Commands;
using Concepts.Mailbox;
using Concepts.Mailbox.Messages;

namespace Domain.Mailbox.Messages
{
    public class AddTag : Command
    {
        public MessageId MessageId { get; set; }
        public TagName Tag { get; set; }
    }
}