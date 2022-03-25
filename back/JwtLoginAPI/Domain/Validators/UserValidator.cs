using FluentValidation;
using JwtLoginAPI.Domain.Queries.Request;

namespace JwtLoginAPI.Domain.Validators
{
    public class UserValidator : AbstractValidator<CreateTokenLoginQueryRequest>
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
