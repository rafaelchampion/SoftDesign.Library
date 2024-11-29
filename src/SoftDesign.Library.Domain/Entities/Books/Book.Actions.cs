using System;
using SoftDesign.Library.Cross.Core.Results;
using SoftDesign.Library.Domain.Entities.Rentals;
using SoftDesign.Library.Domain.Entities.Users;

namespace SoftDesign.Library.Domain.Entities.Books
{
    public partial class Book
    {
        public static DomainResult<Book> Create(string title, string author, string isbn)
        {
            var newBook = new Book(title, author, isbn);
            var validationResult = BookValidator.Validate(newBook);

            return !validationResult.IsSuccess
                ? DomainResult<Book>.Failure(validationResult.ErrorMessage)
                : DomainResult<Book>.Success(newBook);
        }
        
        public DomainResult<Book> Rent(User user, DateTime rentalDate, DateTime expectedReturnDate)
        {
            if (IsRented)
                return DomainResult<Book>.Failure("This book is already rented.");
            var rental = Rental.Create(Id, user.Id, rentalDate, expectedReturnDate);
            if (!rental.IsSuccess)
            {
                return DomainResult<Book>.Failure(rental.ErrorMessage);
            }
            BookRentals.Add(rental.Value);
            return DomainResult<Book>.Success(this);
        }
    }
}