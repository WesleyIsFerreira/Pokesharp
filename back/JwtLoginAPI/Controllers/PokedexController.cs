using JwtLoginAPI.Domain.Commands.Requests;
using JwtLoginAPI.Domain.Commands.Response;
using JwtLoginAPI.Domain.Handlers;
using JwtLoginAPI.Domain.Queries.Response;
using Microsoft.AspNetCore.Mvc;

namespace JwtLoginAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokedexController : ControllerBase
    {
        [HttpPost("CreateAbility")]
        public async Task<ActionResult<CreateAbilityCommandResponse>> CreateAbility(
            [FromServices] IAbilityHandlerCommand handler,
            [FromBody] CreateAbilityCommandRequest command
        )
        {
            return await handler.CreateAbility(command);
        }

        [HttpPost("CreatePokemon")]
        public async Task<ActionResult<CreateItemPokemonCatalogCommandResponse>> CreatePokemon(
            [FromServices] IPokemonHandlerCommand handler,
            [FromBody] CreateItemPokemonCatalogCommandRequest command
        )
        {
            return await handler.CreatePokemon(command);
        }

        [HttpPost("AddPokemonAbility")]
        public async Task<ActionResult<AddPokemonAbilityCommandResponse>> AddPokemonAbility(
            [FromServices] IAddPokemonAbilityHandler handler,
            [FromBody] AddPokemonAbilityCommandRequest command
        )
        {
            return await handler.AddPokemonAbility(command);
        }

        [HttpGet("ListAbilities")]
        public async Task<ActionResult<GetAbilitiesQueryResponse>> ListAbilities(
            [FromServices] IPokemonHandlerQuery handler
        )
        {
            return await handler.ListAbilities();
        }

        
    }
}
