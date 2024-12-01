using SoftDesign.Library.Cross.Core.ResponseModels.Rent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SoftDesign.Library.Cross.Core.ResponseModels.Book
{
    public class BookResponse
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Book title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Book author is required")]
        public string Author { get; set; }
        [Required(ErrorMessage = "Book ISBN is required, must be all digits and must have 10 or 13 characters")]
        public string Isbn { get; set; }
        public bool IsRented { get; set; }
        public string RenterUsername { get; set; }
        public ICollection<RentalResponse> RentalHistory { get; set; }
    }
}