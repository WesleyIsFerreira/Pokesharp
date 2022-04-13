using FluentValidation;
using JwtLoginAPI.Domain.Commands.Requests;

namespace JwtLoginAPI.Domain.Validators
{
    public class PokemonValidator : AbstractValidator<CreateItemPokemonCatalogCommandRequest>
    {
        public PokemonValidator()
        {
            RuleFor(c => c.Name)
                .MaximumLength(20)
                .NotEmpty();

            RuleFor(c => c.Description)
                .MaximumLength(50)
                .NotEmpty();

            RuleFor(c => c.Category)
                .MaximumLength(50)
                .NotEmpty();

            RuleFor(c => c.Gender)
                .IsInEnum();

            RuleFor(c => c.Height)
                .NotEmpty();

            RuleFor(c => c.Weight)
                .NotEmpty();

            RuleFor(c => c.Type)
                .NotEmpty();

            RuleFor(c => c.Weaknesses)
                .NotEmpty();
        }
    }
}
