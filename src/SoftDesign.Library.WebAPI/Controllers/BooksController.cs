using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using SoftDesign.Library.Cross.Core.ResultModels.Book;
using SoftDesign.Library.Cross.Core.Results;
using SoftDesign.Library.Domain.Interfaces.Services;
using SoftDesign.Library.WebAPI.Filters;

namespace SoftDesign.Library.WebAPI.Controllers
{
    [JwtAuthenticationFilter]
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<ActionResult> GetAll()
        {
            var result = await _bookService.GetAll();
            return Json(Result<IEnumerable<BookResult>>.Success(result), JsonRequestBehavior.AllowGet);
        }
    }
}