using FluentValidation;
using JwtLoginAPI.Domain.Queries.Request;

namespace JwtLoginAPI.Domain.Validators
{
    public class UserValidator : AbstractValidator<CreateTokenLoginQueryRequest>
    {
        public UserValidator()
        {
            RuleFor(c => c.UserName)
                .MinimumLength(4)
                .MaximumLength(15)
                .NotEmpty();

            RuleFor(c => c.Password)
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(15)
                .Matches("[A-Z]")
                .Matches("[a-z]")
                .Matches("[0-9]")
                .Matches("[^a-zA-Z0-9]");
        }
        
    }
}
