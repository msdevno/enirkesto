using Bifrost.Concepts;

namespace Concepts.Mailbox
{
    public class Tag : ConceptAs<string>
    {
        public static implicit operator Tag(string tag)
        {
            return new Tag { Value = tag };
        }
    }
}