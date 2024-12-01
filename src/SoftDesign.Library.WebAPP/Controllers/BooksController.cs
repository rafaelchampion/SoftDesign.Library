using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using RestSharp;
using SoftDesign.Library.Cross.Core.ResultModels.Book;
using SoftDesign.Library.Cross.Core.Results;
using SoftDesign.Library.WebAPP.Middleware;

namespace SoftDesign.Library.WebAPP.Controllers
{
    [AuthenticationMiddleware]
    public class BooksController : Controller
    {
        public ActionResult Index()
        {
            var client = ApiRequestMiddleware.CreateClient();
            var token = Session["JwtToken"]?.ToString();
            var request = ApiRequestMiddleware.CreateRequest("/books/getall", Method.GET, token);

            var response = client.Execute<List<BookResult>>(request);

            if (response.IsSuccessful)
            {
                var data = JsonConvert.DeserializeObject<Result<IEnumerable<BookResult>>>(response.Content);
                return View(data.Value.ToList());
            }

            ModelState.AddModelError("", "Failed to load books.");
            return View(new List<BookResult>());
        }
    }
}