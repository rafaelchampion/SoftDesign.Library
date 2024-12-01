using System.Threading.Tasks;
using SoftDesign.Library.Cross.Core.Results;
using SoftDesign.Library.Domain.Entities.Users;
using SoftDesign.Library.Domain.Interfaces.Repositories;
using SoftDesign.Library.Domain.Interfaces.Services;

namespace SoftDesign.Library.Services.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IRepository<User> _userRepository;

        public AuthenticationService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<string>> Authenticate(string username, string password)
        {
            var user = await _userRepository.ReadWithParametersAsNoTracking(u => u.Username == username);
            if (user == null || !user.VerifyPassword(password))
            {
                return Result<string>.Failure("Invalid username or password");
            }
            var token = JwtService.GenerateToken(user.Username, "User");
            return Result<string>.Success(token);
        }
    }
}