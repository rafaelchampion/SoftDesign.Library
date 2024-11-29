using System.Threading.Tasks;
using SoftDesign.Library.Cross.Core.Results;

namespace SoftDesign.Library.Domain.Interfaces.Services
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResult> AuthenticateAsync(string username, string password);
    }
}