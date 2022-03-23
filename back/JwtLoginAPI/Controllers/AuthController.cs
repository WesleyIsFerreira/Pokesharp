using JwtLoginAPI.Domain.Commands.Requests;
using JwtLoginAPI.Domain.Commands.Response;
using JwtLoginAPI.Domain.Handlers;
using JwtLoginAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using JwtLoginAPI.Domain.Queries.Request;
using JwtLoginAPI.Domain.Queries.Response;

namespace JwtLoginAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("Register")]
        public async Task<ActionResult<CreateUserResponse>> Register(
            [FromServices]IUserHandlerCommand handler,
            [FromBody]CreateUserRequest command
        )
        {
            return await handler.CreateUser(command);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(
            [FromServices]IUserHandlerQuery handler,
            [FromBody]CreateTokenLoginRequest query
        )
        {
            try
            {
                CreateTokenLoginResponse resp = await handler.generateToken(query);

                if(resp != null && resp.Success)
                {
                    return Ok(resp);

                }
                else
                {
                    return BadRequest(resp);
                }
            }catch (Exception ex)
            {
                return BadRequest(
                    ex
                );
            }
        }
    }
}
