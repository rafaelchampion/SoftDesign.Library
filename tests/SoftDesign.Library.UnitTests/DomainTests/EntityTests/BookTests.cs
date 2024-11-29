using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoftDesign.Library.Domain.Entities.Books;

namespace SoftDesign.Library.UnitTests.DomainTests.EntityTests
{
    [TestClass]
    public class BookTests
    {
        [TestMethod]
        public void CreateBook_ShouldSucceed_WhenValidDetailsAreProvided()
        {
            // Arrange
            const string title = "Clean Code";
            const string author = "Robert C. Martin";
            const string isbn = "9780132350884";
            // Act
            var result = Book.Create(title, author, isbn);
            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Title.Should().Be(title);
            result.Value.Author.Should().Be(author);
            result.Value.Isbn.Should().Be(isbn);
        }

        [TestMethod]
        public void CreateBook_ShouldFail_WhenTitleIsEmpty()
        {
            // Arrange
            const string title = "";
            const string author = "Robert C. Martin";
            const string isbn = "9780132350884";
            // Act
            var result = Book.Create(title, author, isbn);
            // Assert
            result.IsSuccess.Should().BeFalse();
            result.ErrorMessage.Should().Be("Title cannot be empty.");
        }

        [TestMethod]
        public void CreateBook_ShouldFail_WhenIsbnIsInvalid()
        {
            // Arrange
            const string title = "Clean Code";
            const string author = "Robert C. Martin";
            const string isbn = "InvalidISBN";
            // Act
            var result = Book.Create(title, author, isbn);
            // Assert
            result.IsSuccess.Should().BeFalse();
            result.ErrorMessage.Should().Be("Invalid ISBN format.");
        }

        // [TestMethod]
        // public void UpdateDetails_ShouldSucceed_WhenValidDetailsAreProvided()
        // {
        //     // Arrange
        //     var bookResult = Book.Create("Clean Code", "Robert C. Martin", "9780132350884");
        //     var book = bookResult.Value;
        //     const string newTitle = "Clean Architecture";
        //     const string newAuthor = "Robert C. Martin";
        //     const string newIsbn = "9780134494166";
        //
        //     // Act
        //     var updateResult = book.UpdateDetails(newTitle, newAuthor, newIsbn);
        //
        //     // Assert
        //     updateResult.IsSuccess.Should().BeTrue();
        //     book.Title.Should().Be(newTitle);
        //     book.Author.Should().Be(newAuthor);
        //     book.Isbn.Should().Be(newIsbn);
        // }
        //
        // [TestMethod]
        // public void UpdateDetails_ShouldFail_WhenTitleExceedsMaxLength()
        // {
        //     // Arrange
        //     var bookResult = Book.Create("Clean Code", "Robert C. Martin", "9780132350884");
        //     var book = bookResult.Value;
        //     var longTitle = new string('A', 256); // Exceeds max length
        //
        //     // Act
        //     var updateResult = book.UpdateDetails(longTitle, book.Author, book.Isbn);
        //
        //     // Assert
        //     updateResult.IsSuccess.Should().BeFalse();
        //     updateResult.ErrorMessage.Should().Be("Title cannot exceed 255 characters.");
        // }
        //
        // [TestMethod]
        // public void IsRented_ShouldReturnTrue_WhenBookIsCurrentlyRented()
        // {
        //     // Arrange
        //     var bookResult = Book.Create("Clean Code", "Robert C. Martin", "9780132350884");
        //     var book = bookResult.Value;
        //     var user = new User { Username = "testuser" };
        //     book.RentBook(user, DateTime.Now, DateTime.Now.AddDays(7));
        //
        //     // Act
        //     var isRented = book.IsRented;
        //
        //     // Assert
        //     isRented.Should().BeTrue();
        // }

        [TestMethod]
        public void IsRented_ShouldReturnFalse_WhenBookHasNoActiveRentals()
        {
            // Arrange
            var bookResult = Book.Create("Clean Code", "Robert C. Martin", "9780132350884");
            var book = bookResult.Value;
            // Act
            var isRented = book.IsRented;
            // Assert
            isRented.Should().BeFalse();
        }
    }
}