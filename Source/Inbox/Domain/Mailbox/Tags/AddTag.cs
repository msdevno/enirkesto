using Bifrost.Commands;
using Concepts.Mailbox;

namespace Domain.Mailbox.Tags
{
    public class AddTag : Command
    {
        public Tag  Tag { get; set; }
    }
}