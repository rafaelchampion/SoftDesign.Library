using System.Threading.Tasks;
using SoftDesign.Library.Cross.Core.Results;

namespace SoftDesign.Library.Domain.Interfaces.Services
{
    public interface IAuthenticationService
    {
        Task<Result<string>> Authenticate(string username, string password);
    }
}