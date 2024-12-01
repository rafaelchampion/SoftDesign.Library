using System.Linq;
using System.Threading.Tasks;
using SoftDesign.Library.Cross.Core.Results;
using SoftDesign.Library.Domain.Entities.Users;
using SoftDesign.Library.Domain.Interfaces.Repositories;
using SoftDesign.Library.Domain.Interfaces.Services;

namespace SoftDesign.Library.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<int>> RentersCount()
        {
            var result = await _userRepository.ReadAllWithParametersAsNoTrackingIncluding(x => x.UserRentals.Count() > 0, includes: x => x.UserRentals);
            return Result<int>.Success(result.Count());
        }

        public async Task<Result<string>> GreatestRenter()
        {
            var result = await _userRepository.ReadAllWithParametersAsNoTrackingIncluding(x => x.UserRentals.Count() > 0, includes: x => x.UserRentals);
            return Result<string>.Success(result.OrderByDescending(x=>x.UserRentals.Count()).Take(1).FirstOrDefault().Username);
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