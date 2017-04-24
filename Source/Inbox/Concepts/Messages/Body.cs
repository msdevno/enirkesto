using Bifrost.Concepts;

namespace Concepts.Messages
{
    public class Body : ConceptAs<string>
    {
        public static implicit operator Body(string body)
        {
            return new Body { Value = body };
        }
    }
}