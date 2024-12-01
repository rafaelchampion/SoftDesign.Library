using System.Threading.Tasks;
using System.Web.Mvc;
using SoftDesign.Library.Cross.Core.RequestModels.User;
using SoftDesign.Library.Cross.Core.ResponseModels.Book;
using SoftDesign.Library.Cross.Core.Results;
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
            try
            {
                var result = await _userService.Create(model.Username, model.Password, model.Email);
                if (!result.IsSuccess)
                {
                    return Json(Result<bool>.Failure(result.ErrorMessage), JsonRequestBehavior.AllowGet);
                }
                return Json(Result.Success());
            }
            catch (System.Exception ex)
            {

                return Json(Result<bool>.Failure(ex.Message), JsonRequestBehavior.AllowGet);
            }
        }

        public async Task<ActionResult> CountRenters()
        {
            try
            {
                var result = await _userService.RentersCount();
                if (!result.IsSuccess)
                {
                    return Json(Result<long>.Failure(result.ErrorMessage), JsonRequestBehavior.AllowGet);
                }
                return Json(Result.Success());
            }
            catch (System.Exception ex)
            {
                return Json(Result<long>.Failure(ex.Message), JsonRequestBehavior.AllowGet);
            }
        }

        public async Task<ActionResult> GreatestRenter()
        {
            try
            {
                var result = await _userService.GreatestRenter();
                if (!result.IsSuccess)
                {
                    return Json(Result<string>.Failure(result.ErrorMessage), JsonRequestBehavior.AllowGet);
                }
                return Json(Result.Success());
            }
            catch (System.Exception ex)
            {
                return Json(Result<string>.Failure(ex.Message), JsonRequestBehavior.AllowGet);
            }
        }
    }
}