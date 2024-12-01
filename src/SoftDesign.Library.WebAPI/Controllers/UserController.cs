using System.Threading.Tasks;
using System.Web.Mvc;
using SoftDesign.Library.Cross.Core.RequestModels.User;
using SoftDesign.Library.Domain.Interfaces.Services;

namespace SoftDesign.Library.WebAPI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<ActionResult> Create(UserCreateRequestModel model)
        {
            var result = await _userService.Create(model.Username, model.Password, model.Email);
            return null;
        }
    }
}