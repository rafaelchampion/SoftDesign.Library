using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Newtonsoft.Json;
using RestSharp;
using SoftDesign.Library.Cross.Core.ResponseModels.Book;
using SoftDesign.Library.Cross.Core.ResponseModels.Rent;
using SoftDesign.Library.Cross.Core.Results;
using SoftDesign.Library.Cross.Core.ViewModels;
using SoftDesign.Library.WebAPP.Middleware;

namespace SoftDesign.Library.WebAPP.Controllers
{
    [AuthenticationMiddleware]
    public class BooksController : BaseController
    {
        public ActionResult Index(BookListViewModel model)
        {
            if (model == null)
            {
                model = new BookListViewModel();
            }
            var client = ApiRequestMiddleware.CreateClient();
            var token = Session["JwtToken"]?.ToString();
            var parameters = new Dictionary<string, object>
            {
                { "searchQuery", model.SearchQuery }
            };
            var request = ApiRequestMiddleware.CreateRequest("/books/getall", Method.GET, token, parameters: parameters);

            var response = client.Execute<List<BookResponse>>(request);

            if (response.IsSuccessful)
            {
                var data = JsonConvert.DeserializeObject<Result<IEnumerable<BookResponse>>>(response.Content, new JsonSerializerSettings
                {
                    DateTimeZoneHandling = DateTimeZoneHandling.RoundtripKind
                });
                model.BookList = data.Value.ToList();
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return View(new BookResponse());
            }

            var client = ApiRequestMiddleware.CreateClient();
            var token = Session["JwtToken"]?.ToString();
            var parameters = new Dictionary<string, object>
            {
                { "id", id }
            };
            var request = ApiRequestMiddleware.CreateRequest("/books/get", Method.GET, token, null, parameters);

            var response = client.Execute<BookResponse>(request);

            if (response.IsSuccessful)
            {
                var data = JsonConvert.DeserializeObject<Result<BookResponse>>(response.Content, new JsonSerializerSettings
                {
                    DateTimeZoneHandling = DateTimeZoneHandling.Local
                });
                var failureRedirect = RedirectOnFailure(data, "Book not found.");
                if (failureRedirect != null)
                {
                    return failureRedirect;
                }
                return View(data.Value);
            }

            return View(new BookResponse());
        }

        [HttpPost]
        public ActionResult Edit(BookResponse book)
        {
            var client = ApiRequestMiddleware.CreateClient();
            var token = Session["JwtToken"]?.ToString();
            var body = new { book };
            var newBook = book.Id == 0;
            var requestUrl = newBook ? "/books/create" : "/books/updatedetails";

            var request = ApiRequestMiddleware.CreateRequest(requestUrl, Method.POST, token, body);

            var response = client.Execute<BookResponse>(request);

            if (response.IsSuccessful)
            {
                var data = JsonConvert.DeserializeObject<Result<BookResponse>>(response.Content);
                var failureRedirect = RedirectOnFailure(data, data.ErrorMessage);
                if (failureRedirect != null)
                {
                    return failureRedirect;
                }
                if (newBook)
                {
                    TempData["CreateSuccess"] = true;
                }
                else
                {
                    TempData["UpdateSuccess"] = true;
                }
                return View(data.Value);
            }

            return View(new BookResponse());
        }

        [HttpPost]
        public ActionResult RentBook(long bookId)
        {
            var client = ApiRequestMiddleware.CreateClient();
            var token = Session["JwtToken"]?.ToString();
            var userId = (long)Session["UserId"];
            var body = new { bookId, userId };
            var request = ApiRequestMiddleware.CreateRequest("/books/rent", Method.POST, token, body);

            var response = client.Execute<List<RentalResponse>>(request);

            if (response.IsSuccessful)
            {
                var data = JsonConvert.DeserializeObject<Result<RentalResponse>>(response.Content);
                var failureRedirect = RedirectOnFailure(data, data.ErrorMessage);
                if (failureRedirect != null)
                {
                    return failureRedirect;
                }
                TempData["BookRentSuccess"] = true;
                return RedirectToAction("Index", new { model = new BookListViewModel() });
            }

            return View(new RentalResponse());
        }

        [HttpPost]
        public ActionResult ReturnBook(long bookId)
        {
            var client = ApiRequestMiddleware.CreateClient();
            var token = Session["JwtToken"]?.ToString();
            var body = new { bookId };
            var request = ApiRequestMiddleware.CreateRequest("/books/return", Method.POST, token, body);

            var response = client.Execute<List<RentalResponse>>(request);

            if (response.IsSuccessful)
            {
                var data = JsonConvert.DeserializeObject<Result<RentalResponse>>(response.Content);
                var failureRedirect = RedirectOnFailure(data, data.ErrorMessage);
                if (failureRedirect != null)
                {
                    return failureRedirect;
                }
                TempData["BookReturnSuccess"] = true;
                return RedirectToAction("Index", new { model = new BookListViewModel() });
            }

            return View(new RentalResponse());
        }
    }
}