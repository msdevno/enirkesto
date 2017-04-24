using System;
using Bifrost.Concepts;

namespace Concepts.Messages
{
    public class MessageId : ConceptAs<Guid>
    {
        public static implicit operator MessageId(Guid messageId)
        {
            return new MessageId { Value = messageId };
        }
    }
}