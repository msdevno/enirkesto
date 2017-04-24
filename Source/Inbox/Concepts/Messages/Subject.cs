using Bifrost.Concepts;

namespace Concepts.Messages
{
    public class Subject : ConceptAs<string>
    {
        public static implicit operator Subject(string subject)
        {
            return new Subject { Value = subject };
        }
    }
}