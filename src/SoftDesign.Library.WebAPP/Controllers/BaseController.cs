using SoftDesign.Library.Cross.Core.Results;
using System.Web.Mvc;

namespace SoftDesign.Library.WebAPP.Controllers
{
    public class BaseController : Controller
    {
        protected ActionResult RedirectOnFailure(Result result, string errorMessage = null)
        {
            if (result == null || !result.IsSuccess)
            {
                errorMessage = errorMessage ?? result?.ErrorMessage ?? "An unexpected error occurred.";
                return RedirectToAction("Error", "Home", new { errorMessage });
            }

            return null;
        }
    }
}