using Bifrost.Commands;
using Concepts.Messages;

namespace Domain.Messages
{
    public class ReceiveMessage : Command
    {
        public MessageId MessageId { get; set; }
        public Subject Subject { get; set; }
        public Body Body { get; set; }
    }
}