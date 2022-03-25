using JwtLoginAPI.Domain.Commands.Requests;
using JwtLoginAPI.Domain.Commands.Response;
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

        public async Task<CreateAbilityCommandResponse> CreateAbility(CreateAbilityCommandRequest request)
        {
            Ability newAbility = new Ability();
            newAbility.Name = request.Name;
            newAbility.Description = request.Description;

            _context.Abilities.Add(newAbility);
            await _context.SaveChangesAsync();

            return new CreateAbilityCommandResponse
            {
                Id = newAbility.Id,
                name = newAbility.Name,
                description = newAbility.Description
            };
        }

        
    }
}
