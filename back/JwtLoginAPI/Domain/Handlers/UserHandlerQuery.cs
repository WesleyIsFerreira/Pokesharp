using JwtLoginAPI.Domain.Entities;
using JwtLoginAPI.Domain.Queries.Request;
using JwtLoginAPI.Domain.Queries.Response;
using JwtLoginAPI.Domain.Validators;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace JwtLoginAPI.Domain.Handlers
{
    public class UserHandlerQuery : IUserHandlerQuery
    {
        private readonly DataContext _context;
        private readonly IConfiguration configuration;
        public UserHandlerQuery(DataContext context, IConfiguration configuration)
        {
            _context = context;
            this.configuration = configuration;
        }

        public async Task<CreateTokenLoginQueryResponse> generateToken(CreateTokenLoginQueryRequest request)
        {
            var validator = new UserValidator();
            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                return new CreateTokenLoginQueryResponse
                {
                    Token = "",
                    Success = false,
                    Errors = result.Errors 
                };
            }

            var user = await _context.Users.SingleAsync(b => b.UserName == request.UserName);

            if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
                return new CreateTokenLoginQueryResponse
                {
                    Token = "",
                    Success = false,
                };

            return new CreateTokenLoginQueryResponse
            {
                Token = CreateToken(user)
            };
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                this.configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    signingCredentials: creds,
                    expires: DateTime.Now.AddDays(1));

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
