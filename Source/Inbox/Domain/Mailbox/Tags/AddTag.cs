using Bifrost.Commands;
using Concepts.Mailbox;

namespace Domain.Mailbox.Tags
{
    public class AddTag : Command
    {
        public TagName  Tag { get; set; }
    }
}