using System;
using Bifrost.Read;
using Concepts.Mailbox;
using Concepts.Mailbox.Messages;

namespace Read.Mailbox.Messages
{
    public class Message : IReadModel
    {
        public Message()
        {
            Tags = new Tag[0];
        }

        public Guid Id 
        {
            get { return MessageId.Value; }
            set { MessageId = value; }
        }

        public Sender From {get; set; }

        public Inbox Inbox { get; set; }
        public MessageId MessageId { get; set; }

        public Subject Subject { get; set; }

        public Body Body { get; set; }

        public DateTimeOffset Received { get; set; }

        public Tag[] Tags { get; set; }       
    }
}