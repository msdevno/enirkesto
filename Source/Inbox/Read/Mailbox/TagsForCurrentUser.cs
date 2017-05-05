using System.Linq;
using Bifrost.Read;

namespace Read.Mailbox
{
    public class TagsForCurrentUser : IQueryFor<Tag>
    {

        IReadModelRepositoryFor<Tag> _tagRepository;

        public TagsForCurrentUser(IReadModelRepositoryFor<Tag> tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public IQueryable<Tag> Query =>  _tagRepository.Query; //.Where(m => m.User == Guid.Parse("c86a7bc4-c1bf-4e3f-8190-f3550db008ec"));
    }
}