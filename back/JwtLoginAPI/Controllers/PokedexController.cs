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
        public async Task<IActionResult> CreateAbility(
            [FromServices] IAbilityHandlerCommand handler,
            [FromBody] CreateAbilityCommandRequest command
        )
        {
            return Ok(await handler.CreateAbility(command));
        }

        [HttpPost("CreatePokemon")]
        public async Task<ActionResult<CreateItemPokemonCatalogCommandResponse>> CreatePokemon(
            [FromServices] IPokemonHandlerCommand handler,
            [FromForm] CreateItemPokemonCatalogCommandRequest command
        )
        {
            return await handler.CreatePokemon(command);
        }

        [HttpGet("ListAbilities")]
        public async Task<ActionResult<GetAbilitiesQueryResponse>> ListAbilities(
            [FromServices] IPokemonHandlerQuery handler
        )
        {
            return await handler.ListAbilities();
        }

        [HttpGet("ListPokemons")]
        public async Task<IActionResult> ListPokemons(
            [FromServices] IPokemonHandlerQuery handler
        )
        {
            var temp = await handler.ListPokemons();
            return Ok(temp);
        }

    }
}
