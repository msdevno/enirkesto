using System;
using Bifrost.Concepts;

namespace Concepts.Messages
{
    public class Inbox : ConceptAs<Guid>
    {
        public static implicit operator Inbox(Guid inbox)
        {
            return new Inbox { Value = inbox };
        }
    }
}