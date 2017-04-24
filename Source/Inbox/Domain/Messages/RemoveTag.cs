using Bifrost.Commands;
using Concepts.Messages;

namespace Domain.Messages
{
    public class RemoveTag : Command
    {
        public MessageId MessageId { get; set; }
        public Tag Tag { get; set; }
    }
}