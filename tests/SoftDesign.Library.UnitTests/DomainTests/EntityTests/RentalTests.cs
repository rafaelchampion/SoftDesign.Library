using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoftDesign.Library.Domain.Entities.Rentals;

namespace SoftDesign.Library.UnitTests.DomainTests.EntityTests
{
    [TestClass]
    public class RentalTests
    {
        [TestMethod]
    public void CreateRental_ShouldSucceed_WhenValidDetailsAreProvided()
    {
        // Arrange
        var rentalDate = DateTime.Now;
        var expectedReturnDate = rentalDate.AddDays(7);
        var bookId = 1;
        var userId = 1;
        // Act
        var result = Rental.Create(bookId, userId, rentalDate, expectedReturnDate);
        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.BookId.Should().Be(bookId);
        result.Value.UserId.Should().Be(userId);
    }

    [TestMethod]
    public void CreateRental_ShouldFail_WhenRentalDateIsAfterReturnDate()
    {
        // Arrange
        var rentalDate = DateTime.Now;
        var expectedReturnDate = rentalDate.AddDays(-1);
        var bookId = 1;
        var userId = 1;
        // Act
        var result = Rental.Create(bookId, userId, rentalDate, expectedReturnDate);
        // Assert
        result.IsSuccess.Should().BeFalse();
        result.ErrorMessage.Should().Be("Rental date cannot be later than expected return date.");
    }

    [TestMethod]
    public void ReturnBook_ShouldSucceed_WhenReturnDateIsValid()
    {
        // Arrange
        var rentalResult = Rental.Create(1, 1, DateTime.Now, DateTime.Now.AddDays(7));
        var rental = rentalResult.Value;
        var returnDate = DateTime.Now.AddDays(5);
        // Act
        var returnResult = rental.ReturnBook(returnDate);
        // Assert
        returnResult.IsSuccess.Should().BeTrue();
        rental.ActualReturnDate.Should().Be(returnDate);
    }

    [TestMethod]
    public void ReturnBook_ShouldFail_WhenBookAlreadyReturned()
    {
        // Arrange
        var rentalResult = Rental.Create(1, 1, DateTime.Now, DateTime.Now.AddDays(7));
        var rental = rentalResult.Value;
        var returnDate = DateTime.Now.AddDays(5);
        rental.ReturnBook(returnDate);
        // Act
        var returnResult = rental.ReturnBook(DateTime.Now.AddDays(6));
        // Assert
        returnResult.IsSuccess.Should().BeFalse();
        returnResult.ErrorMessage.Should().Be("The book has already been returned.");
    }
    }
}