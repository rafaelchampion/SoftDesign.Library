using SoftDesign.Library.Cross.Core.Results;

namespace SoftDesign.Library.Domain.Entities.Rentals
{
    internal static class RentalValidator
    {
        internal static Result Validate(Rental rental)
        {
            if (rental.RentalDate > rental.ExpectedReturnDate)
                return Result<Rental>.Failure("Rental date cannot be later than expected return date.");
            return Result.Success();
        }
    }
}