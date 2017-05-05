using System;
using Bifrost.Concepts;

namespace Concepts.Mailbox.Tags
{
    public class TagId : ConceptAs<Guid>
    {
        public static implicit operator TagId(Guid tagId)
        {
            return new TagId { Value = tagId };
        }
    }
}