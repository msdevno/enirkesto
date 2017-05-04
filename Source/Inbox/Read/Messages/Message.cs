using Bifrost.Read;
using Concepts.Messages;

namespace Read.Messages
{
    public class Message : IReadModel
    {
        public Message()
        {
            Tags = new Tag[0];
        }

        public Sender From {get; set; }

        public Inbox Inbox { get; set; }
        public MessageId MessageId { get; set; }

        public Subject Subject { get; set; }

        public Body Body { get; set; }

        public Tag[] Tags { get; set; }       
    }
}