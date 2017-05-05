using Bifrost.Concepts;

namespace Concepts.Mailbox
{
    public class TagName : ConceptAs<string>
    {
        public static implicit operator TagName(string tag)
        {
            return new TagName { Value = tag };
        }
    }
}