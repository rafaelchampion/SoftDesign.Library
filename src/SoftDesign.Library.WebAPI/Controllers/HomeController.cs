using SoftDesign.Library.Cross.Core.ResponseModels.Book;
using SoftDesign.Library.Cross.Core.Results;
using SoftDesign.Library.Cross.Core.ViewModels;
using SoftDesign.Library.Domain.Interfaces.Services;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SoftDesign.Library.WebAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IRentalService _rentalService;
        private readonly IUserService _userService;

        public HomeController(IBookService bookService, IRentalService rentalService, IUserService userService)
        {
            _bookService = bookService;
            _rentalService = rentalService;
            _userService = userService;
        }

        public async Task<ActionResult> DashboardInfo()
        {
            try
            {
                var bookTotalResult = await _bookService.CountTotal();
                var rentedCountResult = await _bookService.CountRented();
                var renterCountResult = await _userService.RentersCount();
                var greatestRenterResult = await _userService.GreatestRenter();
                var featuredBookResult = await _bookService.FeaturedBook();
                var mostRentedResult = await _bookService.MostRented();

                var dashboardViewModel = new DashboardViewModel()
                {
                    ActiveRenterCount = renterCountResult.Value,
                    FeaturedBook = featuredBookResult.Value,
                    GreatestRenter = greatestRenterResult.Value,
                    MostRentedBook = mostRentedResult.Value,
                    RentedBookCount = rentedCountResult.Value,
                    TotalBookCount = bookTotalResult.Value
                };

                return Json(Result<DashboardViewModel>.Success(dashboardViewModel), JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception ex)
            {
                return Json(Result.Failure(ex.Message), JsonRequestBehavior.AllowGet);
                throw;
            }
        }
    }
}