using System;
using SoftDesign.Library.Cross.Core.Results;

namespace SoftDesign.Library.Domain.Entities.Rentals
{
    public partial class Rental
    {
        public static DomainResult<Rental> Create(long bookId, long userId, DateTime rentalDate, DateTime expectedReturnDate)
        {
            var newRental = new Rental(bookId, userId, rentalDate, expectedReturnDate);
            var validationResult = RentalValidator.Validate(newRental);
            return !validationResult.IsSuccess
                ? DomainResult<Rental>.Failure(validationResult.ErrorMessage)
                : DomainResult<Rental>.Success(newRental);
        }

        public DomainResult ReturnBook(DateTime returnDate)
        {
            if (ActualReturnDate != null)
                return DomainResult.Failure("The book has already been returned.");
            if (returnDate < RentalDate)
                return DomainResult.Failure("Return date cannot be earlier than the rental date.");
            ActualReturnDate = returnDate;
            return DomainResult.Success();
        }
    }
}