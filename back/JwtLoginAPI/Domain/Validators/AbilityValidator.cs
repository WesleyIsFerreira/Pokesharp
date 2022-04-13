using FluentValidation;
using JwtLoginAPI.Domain.Entities;

namespace JwtLoginAPI.Domain.Validators
{
    public class AbilityValidator : AbstractValidator<Ability>
    {
        public AbilityValidator()
        {
            RuleFor(c => c.Name)
                .MaximumLength(20)
                .NotEmpty();
            
            RuleFor(c => c.Description)
                .MaximumLength(50)
                .NotEmpty();
        }

    }
}
