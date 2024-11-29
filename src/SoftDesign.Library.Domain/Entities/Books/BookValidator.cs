using SoftDesign.Library.Cross.Core.Results;

namespace SoftDesign.Library.Domain.Entities.Books
{
    internal static class BookValidator
    {
        internal static Result Validate(Book book)
        {
            if (string.IsNullOrWhiteSpace(book.Title))
                return Result.Failure("Title cannot be empty.");
            if (book.Title.Length > 255)
                return Result.Failure("Title cannot exceed 255 characters.");
            if (string.IsNullOrWhiteSpace(book.Author))
                return Result.Failure("Author cannot be empty.");
            if (book.Author.Length > 255)
                return Result.Failure("Author cannot exceed 255 characters.");
            if (string.IsNullOrWhiteSpace(book.Isbn))
                return Result.Failure("ISBN cannot be empty.");
            if (!IsbnValidator.IsValidIsbn(book.Isbn))
                return Result.Failure("Invalid ISBN format.");
            return Result.Success();
        }
    }
}