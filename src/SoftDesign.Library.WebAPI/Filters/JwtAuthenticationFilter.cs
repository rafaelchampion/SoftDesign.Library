using SoftDesign.Library.Services;
using System.Web;
using System.Web.Mvc;

namespace SoftDesign.Library.WebAPI.Filters
{
    public class JwtAuthenticationFilter : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var authHeader = httpContext.Request.Headers["Authorization"];
            if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer "))
            {
                return false;
            }

            var token = authHeader.Substring("Bearer ".Length).Trim();
            try
            {
                var principal = JwtService.ValidateToken(token);
                httpContext.User = principal;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!AuthorizeCore(filterContext.HttpContext))
            {
                filterContext.Result = new HttpUnauthorizedResult("Invalid or missing token");
            }
        }
    }
}