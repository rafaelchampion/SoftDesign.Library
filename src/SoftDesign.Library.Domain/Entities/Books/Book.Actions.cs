using System;
using SoftDesign.Library.Cross.Core.Results;
using SoftDesign.Library.Domain.Entities.Rentals;
using SoftDesign.Library.Domain.Entities.Users;

namespace SoftDesign.Library.Domain.Entities.Books
{
    public partial class Book
    {
        public static Result<Book> Create(string title, string author, string isbn)
        {
            var newBook = new Book(title.Trim(), author.Trim(), isbn.Trim());
            var validationResult = BookValidator.Validate(newBook);

            return !validationResult.IsSuccess
                ? Result<Book>.Failure(validationResult.ErrorMessage)
                : Result<Book>.Success(newBook);
        }

        public Result<Book> UpdateTitle(string title)
        {
            Title = title.Trim();
            var validationResult = BookValidator.Validate(this);
            return !validationResult.IsSuccess
                ? Result<Book>.Failure(validationResult.ErrorMessage)
                : Result<Book>.Success(this);
        }

        public Result<Book> UpdateAuthor(string author)
        {
            Author = author.Trim();
            var validationResult = BookValidator.Validate(this);
            return !validationResult.IsSuccess
                ? Result<Book>.Failure(validationResult.ErrorMessage)
                : Result<Book>.Success(this);
        }

        public Result<Book> UpdateISBN(string isbn)
        {
            Isbn = isbn.Trim();
            var validationResult = BookValidator.Validate(this);
            return !validationResult.IsSuccess
                ? Result<Book>.Failure(validationResult.ErrorMessage)
                : Result<Book>.Success(this);
        }

        public Result<Book> Rent(User user, DateTime rentalDate, DateTime expectedReturnDate)
        {
            if (IsRented)
                return Result<Book>.Failure("This book is already rented.");
            var rental = Rental.Create(Id, user.Id, rentalDate, expectedReturnDate);
            if (!rental.IsSuccess)
            {
                return Result<Book>.Failure(rental.ErrorMessage);
            }
            BookRentals.Add(rental.Value);
            return Result<Book>.Success(this);
        }
    }
}