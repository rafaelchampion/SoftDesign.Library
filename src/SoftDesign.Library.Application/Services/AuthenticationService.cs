using System.Threading.Tasks;
using SoftDesign.Library.Cross.Core.ResponseModels.Authentication;
using SoftDesign.Library.Cross.Core.Results;
using SoftDesign.Library.Domain.Interfaces.Repositories;
using SoftDesign.Library.Domain.Interfaces.Services;

namespace SoftDesign.Library.Services.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<AuthenticationResponse>> Authenticate(string username, string password)
        {
            var user = await _userRepository.ReadWithParametersAsNoTracking(u => u.Username == username);
            if (user == null || !user.VerifyPassword(password))
            {
                return Result<AuthenticationResponse>.Failure("Invalid username or password");
            }
            var token = JwtService.GenerateToken(user.Username, "User");
            return Result<AuthenticationResponse>.Success(new AuthenticationResponse()
            {
                Token = token,
                UserId = user.Id,
            });
        }
    }
}