using Bifrost.Concepts;

namespace Concepts.Mailbox.Messages
{
    public class Body : ConceptAs<string>
    {
        public static implicit operator Body(string body)
        {
            return new Body { Value = body };
        }
    }
}