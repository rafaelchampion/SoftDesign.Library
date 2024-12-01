using System.Threading.Tasks;
using System.Web.Mvc;
using SoftDesign.Library.Cross.Core.ResponseModels.Authentication;
using SoftDesign.Library.Cross.Core.Results;
using SoftDesign.Library.Domain.Interfaces.Services;

namespace SoftDesign.Library.WebAPI.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationService _authService;

        public AuthenticationController(IAuthenticationService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<ActionResult> Login(string username, string password)
        {
            var result = await _authService.Authenticate(username, password);
            if (result == null || !result.IsSuccess)
            {
                return Json(Result<AuthenticationResponse>.Failure(result.ErrorMessage));
            }
            return Json(Result<AuthenticationResponse>.Success(result.Value));
        }
    }
}