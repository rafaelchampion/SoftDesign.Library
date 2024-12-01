using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SoftDesign.Library.WebAPP.Middleware
{
    public class AuthenticationMiddleware : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = filterContext.HttpContext.Session;
            var token = session?["JwtToken"]?.ToString();

            if (string.IsNullOrEmpty(token) &&
                !filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.Equals("Account",
                    StringComparison.OrdinalIgnoreCase))
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    { "controller", "Account" },
                    { "action", "Login" }
                });
                var requestedUrl = filterContext?.HttpContext?.Request?.Url?.ToString();
                HttpContext.Current.Session["ReturnUrl"] = requestedUrl;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}