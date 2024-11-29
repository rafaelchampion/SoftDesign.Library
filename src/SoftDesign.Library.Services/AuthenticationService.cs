using SoftDesign.Library.Cross.Core.Results;
using SoftDesign.Library.Domain.Entities.Users;
using SoftDesign.Library.Domain.Interfaces.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace SoftDesign.Library.Services
{
    public class AuthenticationService
    {
        private readonly IRepository<User> _userRepository;

        public AuthenticationService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public Result<string> Authenticate(string username, string password)
        {
            var user = _userRepository.Find(u => u.Username == username).FirstOrDefault();
            if (user == null || !user.VerifyPassword(password))
            {
                return Result<string>.Failure("Invalid username or password");
            }
            var token = JwtService.GenerateToken(user.Username, "User");
            return Result<string>.Success(token);
        }
    }
}