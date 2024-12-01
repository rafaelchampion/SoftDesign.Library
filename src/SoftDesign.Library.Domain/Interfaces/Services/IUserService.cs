using System.Threading.Tasks;
using SoftDesign.Library.Cross.Core.Results;
using SoftDesign.Library.Domain.Entities.Users;

namespace SoftDesign.Library.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<Result<User>> Create(string username, string password, string email);
    }
}