using JwtLoginAPI.Domain.Commands.Requests;
using JwtLoginAPI.Domain.Commands.Response;
using JwtLoginAPI.Domain.Entities;
using System.Security.Cryptography;

namespace JwtLoginAPI.Domain.Handlers
{
    public class UserHandlerCommand : IUserHandlerCommand
    {
        private readonly DataContext _context;
        public UserHandlerCommand(DataContext context)
        {
            _context = context;
        }

        public async Task<CreateUserResponse> CreateUser(CreateUserRequest request)
        {

            CreatePassword(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            User user = new User();
            user.UserName = request.UserName;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            

            return new CreateUserResponse
            {
                Id = user.Id,
                UserName = user.UserName
            };
        }

        private void CreatePassword(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
