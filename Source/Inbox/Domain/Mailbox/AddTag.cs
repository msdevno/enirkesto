using Bifrost.Commands;
using Concepts.Mailbox;

namespace Domain.Mailbox
{
    public class AddTag : Command
    {
        public TagName  Tag { get; set; }
    }
}