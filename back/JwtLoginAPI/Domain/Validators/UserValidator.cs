using FluentValidation;
using JwtLoginAPI.Domain.Queries.Request;

namespace JwtLoginAPI.Domain.Validators
{
    public class UserValidator : AbstractValidator<CreateTokenLoginRequest>
    {
        public UserValidator()
        {
            RuleFor(c => c.UserName)
                .NotEmpty();

            RuleFor(c => c.Password)
                .NotEmpty();
        }
        
    }
}
