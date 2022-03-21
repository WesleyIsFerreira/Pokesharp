using JwtLoginAPI.Domain.Comands.Requests;
using JwtLoginAPI.Domain.Comands.Response;
using JwtLoginAPI.Domain.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace JwtLoginAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbilityController : ControllerBase
    {
        [HttpPost("CreateAbility")]
        public async Task<ActionResult<CreateAbilityResponse>> Register(
            [FromServices] IAbilityHandlerCommand handler,
            [FromBody] CreateAbilityRequest command
        )
        {
            return await handler.CreateAbility(command);
        }
    }
}
