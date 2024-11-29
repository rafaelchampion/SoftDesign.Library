using System.Web.Mvc;
using System.Web.Security;
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

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<ActionResult> Login(LoginViewModel model)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return View(model);
        //     }
        //
        //     var result = await _authService.AuthenticateAsync(model.Username, model.Password);
        //
        //     if (result.Success)
        //     {
        //         FormsAuthentication.SetAuthCookie(model.Username, model.RememberMe);
        //         return RedirectToAction("Index", "Books");
        //     }
        //
        //     ModelState.AddModelError("", "Invalid credentials");
        //     return View(model);
        // }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}