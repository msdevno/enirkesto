using Bifrost.FluentValidation.Commands;
using FluentValidation;

namespace Domain.Mailbox.Tags
{
    public class AddTagValidation : CommandInputValidator<AddTag>
    {
        public AddTagValidation()
        {
            RuleFor(c => c.Tag).NotEmpty().WithMessage("You must provide a name of the tag");
        }
    }
}
