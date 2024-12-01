using System.Threading.Tasks;
using SoftDesign.Library.Cross.Core.Results;
using SoftDesign.Library.Domain.Entities.Users;
using SoftDesign.Library.Domain.Interfaces.Repositories;
using SoftDesign.Library.Domain.Interfaces.Services;

namespace SoftDesign.Library.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<User>> Create(string username, string password, string email)
        {
            var userResult = User.Create(username, password, email);
            if (userResult.IsSuccess)
            {
                await _userRepository.Create(userResult.Value);
            }
            return userResult;
        }
    }
}