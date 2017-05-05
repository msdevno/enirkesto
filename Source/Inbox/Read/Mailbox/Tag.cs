using System;
using Bifrost.Read;
using Concepts;
using Concepts.Mailbox;
using Concepts.Mailbox.Tags;

namespace Read.Mailbox
{
    public class Tag : IReadModel
    {
        // Due to mapping of Concepts for IdMember not working - we have this
        public Guid Id 
        {
            get { return TagId; }
            set { TagId = value; }
        }

        public TagId TagId { get; set; }
        public User User { get; set;}
        public TagName Name { get; set; }
    }
}