﻿using JwtLoginAPI.Domain.Comands.Requests;
using JwtLoginAPI.Domain.Comands.Response;
using JwtLoginAPI.Domain.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace JwtLoginAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokedexController : ControllerBase
    {
        [HttpPost("CreateAbility")]
        public async Task<ActionResult<CreateAbilityResponse>> CreateAbility(
            [FromServices] IAbilityHandlerCommand handler,
            [FromBody] CreateAbilityRequest command
        )
        {
            return await handler.CreateAbility(command);
        }

        [HttpPost("CreatePokemon")]
        public async Task<ActionResult<CreateItemPokemonCatalogResponse>> CreatePokemon(
            [FromServices] IPokemonHandlerCommand handler,
            [FromBody] CreateItemPokemonCatalogRequest command
        )
        {
            return await handler.CreatePokemon(command);
        }
    }
}
