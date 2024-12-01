using System;

namespace SoftDesign.Library.Cross.Core.ResponseModels.Rental
{
    public class RentalResponse
    {
        public string RenterUsername { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
        public DateTime? ActualReturnDate { get; set; }
    }
}
