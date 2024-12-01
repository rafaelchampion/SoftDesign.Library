using System.ComponentModel.DataAnnotations;

namespace SoftDesign.Library.Cross.Core.RequestModels.Rental
{
    public class RentalRequestModel
    {
        [Required(ErrorMessage = "Book Id is required")]
        public long BookId { get; set; }
        [Required(ErrorMessage = "User Id is required")]
        public long UserId { get; set; }

        public RentalRequestModel()
        {

        }

        public RentalRequestModel(long bookId, long userId)
        {
            BookId = bookId;
            UserId = userId;
        }
    }
}
