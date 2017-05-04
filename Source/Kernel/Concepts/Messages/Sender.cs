using Bifrost.Concepts;

namespace Concepts.Messages
{
    public class Sender : ConceptAs<string>
    {
        public static implicit operator Sender(string sender)
        {
            return new Sender { Value = sender };
        }
    }
}