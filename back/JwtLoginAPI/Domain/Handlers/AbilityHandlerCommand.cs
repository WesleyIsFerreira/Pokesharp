using JwtLoginAPI.Domain.Comands.Requests;
using JwtLoginAPI.Domain.Comands.Response;
using JwtLoginAPI.Domain.Entities;

namespace JwtLoginAPI.Domain.Handlers
{
    public class AbilityHandlerCommand : IAbilityHandlerCommand
    {
        private readonly DataContext _context;
        public AbilityHandlerCommand(DataContext context)
        {
            _context = context;
        }

        public async Task<CreateAbilityResponse> CreateAbility(CreateAbilityRequest request)
        {
            Ability newAbility = new Ability();
            newAbility.Name = request.Name;
            newAbility.Description = request.Description;

            _context.Abilities.Add(newAbility);
            await _context.SaveChangesAsync();

            return new CreateAbilityResponse
            {
                Id = newAbility.Id,
                name = newAbility.Name,
                description = newAbility.Description
            };
        }

        
    }
}
