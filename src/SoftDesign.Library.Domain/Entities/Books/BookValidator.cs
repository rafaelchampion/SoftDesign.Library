using SoftDesign.Library.Cross.Core.Results;

namespace SoftDesign.Library.Domain.Entities.Books
{
    internal static class BookValidator
    {
        internal static DomainResult Validate(Book book)
        {
            if (string.IsNullOrWhiteSpace(book.Title))
                return DomainResult.Failure("Title cannot be empty.");
            if (book.Title.Length > 255)
                return DomainResult.Failure("Title cannot exceed 255 characters.");
            if (string.IsNullOrWhiteSpace(book.Author))
                return DomainResult.Failure("Author cannot be empty.");
            if (book.Author.Length > 255)
                return DomainResult.Failure("Author cannot exceed 255 characters.");
            if (string.IsNullOrWhiteSpace(book.Isbn))
                return DomainResult.Failure("ISBN cannot be empty.");
            if (!IsbnValidator.IsValidIsbn(book.Isbn))
                return DomainResult.Failure("Invalid ISBN format.");
            return DomainResult.Success();
        }
    }
}