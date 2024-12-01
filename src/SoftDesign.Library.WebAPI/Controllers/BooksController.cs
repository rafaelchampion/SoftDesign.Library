using System.Threading.Tasks;
using System.Web.Mvc;
using SoftDesign.Library.Cross.Core.RequestModels.Rental;
using SoftDesign.Library.Cross.Core.ResponseModels.Book;
using SoftDesign.Library.Cross.Core.ResponseModels.Rent;
using SoftDesign.Library.Cross.Core.Results;
using SoftDesign.Library.Domain.Interfaces.Services;
using SoftDesign.Library.WebAPI.Filters;

namespace SoftDesign.Library.WebAPI.Controllers
{
    [JwtAuthenticationFilter]
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IRentalService _rentalService;

        public BooksController(IBookService bookService, IRentalService rentalService)
        {
            _bookService = bookService;
            _rentalService = rentalService;
        }

        public async Task<ActionResult> GetAll(string searchQuery = "")
        {
            var result = await _bookService.GetAll(searchQuery);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> Get(long id)
        {
            var result = await _bookService.Get(id);
            if (result == null)
            {
                return Json(Result<BookResponse>.Failure("Book not found"), JsonRequestBehavior.AllowGet);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> Create(BookResponse book)
        {
            var result = await _bookService.Create(book);
            if (!result.IsSuccess)
            {
                return Json(Result<BookResponse>.Failure(result.ErrorMessage), JsonRequestBehavior.AllowGet);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> UpdateDetails(BookResponse book)
        {
            var result = await _bookService.UpdateDetails(book);
            if (!result.IsSuccess)
            {
                return Json(Result<BookResponse>.Failure(result.ErrorMessage), JsonRequestBehavior.AllowGet);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> Rent(RentalRequestModel model)
        {
            var result = await _rentalService.RentBook(model);
            if (!result.IsSuccess)
            {
                return Json(Result<RentalResponse>.Failure(result.ErrorMessage), JsonRequestBehavior.AllowGet);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> Return(long bookId)
        {
            var result = await _rentalService.ReturnBook(bookId);
            if (!result.IsSuccess)
            {
                return Json(Result<RentalResponse>.Failure(result.ErrorMessage), JsonRequestBehavior.AllowGet);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> FeaturedBook()
        {
            var result = await _bookService.FeaturedBook();
            if (!result.IsSuccess)
            {
                return Json(Result<BookResponse>.Failure(result.ErrorMessage), JsonRequestBehavior.AllowGet);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> MostRented()
        {
            var result = await _bookService.MostRented();
            if (!result.IsSuccess)
            {
                return Json(Result<BookResponse>.Failure(result.ErrorMessage), JsonRequestBehavior.AllowGet);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}