using System.Threading.Tasks;
using SoftDesign.Library.Cross.Core.ResponseModels.Authentication;
using SoftDesign.Library.Cross.Core.Results;

namespace SoftDesign.Library.Domain.Interfaces.Services
{
    public interface IAuthenticationService
    {
        Task<Result<AuthenticationResponse>> Authenticate(string username, string password);
    }
}