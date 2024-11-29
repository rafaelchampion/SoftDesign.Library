using System;
using SoftDesign.Library.Cross.Core.Results;
using SoftDesign.Library.Cross.Core.Security;
using SoftDesign.Library.Domain.Entities.Books;

namespace SoftDesign.Library.Domain.Entities.Users
{
    public partial class User
    {
        public static Result<User> Create(string username, string password, string email)
        {
            var passwordValidationResult = PasswordValidator.Validate(password);
            if (!passwordValidationResult.IsSuccess)
            {
                return Result<User>.Failure(passwordValidationResult.ErrorMessage);
            }
            var newUser = new User(username, password, email);
            var validationResult = UserValidator.Validate(newUser);
            return !validationResult.IsSuccess
                ? Result<User>.Failure(validationResult.ErrorMessage)
                : Result<User>.Success(newUser);
        }

        public static Result<User> Create(string username, string password, string email, string firstName,
            string lastName)
        {
            var newUser = new User(username, password, email, firstName, lastName);
            var validationResult = UserValidator.Validate(newUser);
            return !validationResult.IsSuccess
                ? Result<User>.Failure(validationResult.ErrorMessage)
                : Result<User>.Success(newUser);
        }
        
        public bool VerifyPassword(string password)
        {
            return PasswordHasher.VerifyPassword(password, PasswordHash, PasswordSalt);
        }

        public void RentBook(Book book, DateTime rentalDate, DateTime expectedReturnDate)
        {
            book.Rent(this, rentalDate, expectedReturnDate);
        }
    }
}