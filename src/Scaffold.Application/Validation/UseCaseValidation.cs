using Scaffold.Application.Handlers;

namespace Scaffold.Application.Validation
{
    public class UseCaseValidation : AbstractValidator<UseCaseRequest>
    {
        public UseCaseValidation() 
        {
            RuleFor(a => a.Name)
            .NotEmpty()
            .WithMessage("Field Name is not valid");
        }
    }
}
