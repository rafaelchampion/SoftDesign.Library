using System.Configuration;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;
using RestSharp;
using SoftDesign.Library.Cross.Core.RequestModels.Authentication;
using SoftDesign.Library.Cross.Core.ResponseModels.Authentication;
using SoftDesign.Library.Cross.Core.Results;
using SoftDesign.Library.WebAPP.Middleware;

namespace SoftDesign.Library.WebAPP.Controllers
{
    public class AccountController : Controller
    {
        private readonly string _apiBaseUrl = ConfigurationManager.AppSettings.Get("UrlApi");

        [HttpGet]
        public ActionResult Login()
        {
            return View(new LoginRequestModel(null, null));
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return await Task.FromResult<ActionResult>(View(model));
            }

            var client = ApiRequestMiddleware.CreateClient();
            var request = ApiRequestMiddleware.CreateRequest("/authentication/login", Method.POST);
            request.AddJsonBody(new { username = model.Username, password = model.Password });

            var responseJson = await client.ExecuteAsync(request);
            var response = JsonConvert.DeserializeObject<Result<AuthenticationResponse>>(responseJson.Content);

            if (responseJson.IsSuccessful && response.IsSuccess)
            {
                Session["UserId"] = response.Value.UserId;
                Session["JwtToken"] = response.Value.Token;
                var returnUrl = Session["ReturnUrl"] as string;
                if (!string.IsNullOrEmpty(returnUrl))
                {
                    return await Task.FromResult(Redirect(returnUrl));
                }
                return await Task.FromResult<ActionResult>(RedirectToAction("Index", "Home"));
            }

            ModelState.AddModelError("", "Invalid username or password");
            return await Task.FromResult<ActionResult>(View(model));
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}