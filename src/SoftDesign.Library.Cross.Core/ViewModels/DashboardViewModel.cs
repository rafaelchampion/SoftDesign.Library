using SoftDesign.Library.Cross.Core.ResponseModels.Book;

namespace SoftDesign.Library.Cross.Core.ViewModels
{
    public class DashboardViewModel
    {
        public int TotalBookCount { get; set; }
        public int RentedBookCount { get; set; }
        public int ActiveRenterCount { get; set; }
        public string GreatestRenter { get; set; }

        public BookResponse FeaturedBook { get; set; }
        public BookResponse MostRentedBook { get; set; }
    }
}
