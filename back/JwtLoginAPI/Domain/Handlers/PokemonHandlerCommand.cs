using JwtLoginAPI.Domain.Commands.Entities;
using JwtLoginAPI.Domain.Commands.Requests;
using JwtLoginAPI.Domain.Commands.Response;

namespace JwtLoginAPI.Domain.Handlers
{
    public class PokemonHandlerCommand : IPokemonHandlerCommand
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        public PokemonHandlerCommand(DataContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<CreateItemPokemonCatalogCommandResponse> CreatePokemon(CreateItemPokemonCatalogCommandRequest request)
        {
            string pathDefault = Directory.GetCurrentDirectory();

            string fileName = Path.GetFileNameWithoutExtension(path: request.Photo.FileName);
            string newName = fileName + DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + Guid.NewGuid().ToString("N");

            string extention = Path.GetExtension(path: request.Photo.FileName);

            string oldPath = Path.Combine(pathDefault + "/Domain/Handlers/img/", fileName + extention);
            string newPath = Path.Combine(pathDefault + "/Domain/Handlers/img/", newName + extention);
            

            Pokemon newPokemon = new()
            {
                Name = request.Name,
                Description = request.Description,
                Category = request.Category,
                Gender = request.Gender,
                Height = request.Height,
                Weight = request.Weight,
                Type = request.Type,
                Weaknesses = request.Weaknesses,
                Photo = newName + extention
            };

            using (var fileStream = new FileStream(oldPath, FileMode.Create))
            {
                await request.Photo.CopyToAsync(fileStream);
            }

            System.IO.File.Move(oldPath, newPath);

            try
            {
                _context.Pokemons.Add(newPokemon);
                await _context.SaveChangesAsync();

                var pkAbility = new AddPokemonAbilityCommandRequest();
                pkAbility.AbilitiesId = request.Abilities;
                pkAbility.PokemonId = newPokemon.Id;

                bool resp = await VincPokemonAbility(pkAbility);

                if (!resp)
                {
                    throw new InvalidOperationException("ability not found");
                }

                return new CreateItemPokemonCatalogCommandResponse
                {
                    Id = newPokemon.Id,
                    Name = newPokemon.Name,
                    Description = newPokemon.Description,
                    Category = newPokemon.Category,
                    Gender = newPokemon.Gender,
                    Height = newPokemon.Height,
                    Weight = newPokemon.Weight,
                    Type = newPokemon.Type,
                    Weaknesses = newPokemon.Weaknesses
                };

            } catch (Exception ex)
            {
                return new CreateItemPokemonCatalogCommandResponse
                {
                    Success = false,
                    Error = ex.Message
                };
            }
        }

        public async Task<bool> VincPokemonAbility(AddPokemonAbilityCommandRequest request)
        {
            var success = true;
            var list = request.AbilitiesId;

            foreach (int id in list)
            {

                var ability = await _context.Abilities.FindAsync(id);

                var pokemon = await _context.Pokemons
                    .Where(c => c.Id == request.PokemonId)
                    .Include(c => c.Abilities)
                    .FirstOrDefaultAsync();

                if (ability == null || pokemon == null)
                {
                    success = false;
                }

                pokemon.Abilities.Add(ability);
            };

            if (!success)
            {
                return false;
            }

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
