using System;
using SoftDesign.Library.Cross.Core.Results;

namespace SoftDesign.Library.Domain.Entities.Rentals
{
    public partial class Rental
    {
        public static Result<Rental> Create(long bookId, long userId, DateTime rentalDate, DateTime expectedReturnDate)
        {
            var newRental = new Rental(bookId, userId, rentalDate, expectedReturnDate);
            var validationResult = RentalValidator.Validate(newRental);
            return !validationResult.IsSuccess
                ? Result<Rental>.Failure(validationResult.ErrorMessage)
                : Result<Rental>.Success(newRental);
        }

        public Result ReturnBook(DateTime returnDate)
        {
            if (ActualReturnDate != null)
                return Result.Failure("The book has already been returned.");
            if (returnDate < RentalDate)
                return Result.Failure("Return date cannot be earlier than the rental date.");
            ActualReturnDate = returnDate;
            return Result.Success();
        }
    }
}