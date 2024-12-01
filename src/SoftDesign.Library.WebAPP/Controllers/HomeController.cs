using System.Web.Mvc;
using Newtonsoft.Json;
using RestSharp;
using SoftDesign.Library.Cross.Core.Results;
using SoftDesign.Library.Cross.Core.ViewModels;
using SoftDesign.Library.WebAPP.Middleware;

namespace SoftDesign.Library.WebAPP.Controllers
{
    [AuthenticationMiddleware]
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var client = ApiRequestMiddleware.CreateClient();
            var token = Session["JwtToken"]?.ToString();
            var request = ApiRequestMiddleware.CreateRequest("/home/dashboardinfo", Method.GET, token);

            var response = client.Execute<DashboardViewModel>(request);

            if (response.IsSuccessful)
            {
                var data = JsonConvert.DeserializeObject<Result<DashboardViewModel>>(response.Content);
                var failureRedirect = RedirectOnFailure(data, data.ErrorMessage);
                if (failureRedirect != null)
                {
                    return failureRedirect;
                }
                return View(data.Value);
            }
            return View(new DashboardViewModel());
        }

        public ActionResult Error(string errorMessage)
        {
            return View("Error", model: errorMessage);
        }
    }
}