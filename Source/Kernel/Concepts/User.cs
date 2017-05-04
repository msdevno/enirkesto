using System;
using Bifrost.Concepts;

namespace Concepts
{
    public class User : ConceptAs<Guid>
    {
        public static implicit operator User(Guid user)
        {
            return new User { Value = user };
        }
    }
}