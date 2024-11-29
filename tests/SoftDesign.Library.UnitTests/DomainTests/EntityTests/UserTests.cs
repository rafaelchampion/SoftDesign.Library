using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoftDesign.Library.Domain.Entities.Users;

namespace SoftDesign.Library.UnitTests.DomainTests.EntityTests
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void CreateUser_ShouldSucceed_WhenValidDetailsAreProvided()
        {
            // Arrange
            const string username = "johndoe";
            const string password = "password123AAA@";
            const string email = "john.doe@example.com";
            const string firstName = "John";
            const string lastName = "Doe";
            // Act
            var result = User.Create(username, password, email, firstName, lastName);
            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Username.Should().Be(username);
            result.Value.Email.Should().Be(email);
        }

        [TestMethod]
        public void CreateUser_ShouldFail_WhenEmailIsInvalid()
        {
            // Arrange
            const string username = "johndoe";
            const string password = "password123AAA";
            const string email = "invalidemail";
            const string firstName = "John";
            const string lastName = "Doe";
            // Act
            var result = User.Create(username, password, email, firstName, lastName);
            // Assert
            result.IsSuccess.Should().BeFalse();
            result.ErrorMessage.Should().Be("Invalid email format.");
        }

        // [TestMethod]
        // public void UpdateUserDetails_ShouldSucceed_WhenValidDetailsAreProvided()
        // {
        //     // Arrange
        //     var userResult = User.Create("johndoe", "hashedpassword", "john.doe@example.com", "John", "Doe");
        //     var user = userResult.Value;
        //     const string newUsername = "johnnydoe";
        //     const string newEmail = "johnny.doe@example.com";
        //     // Act
        //     var updateResult = user.UpdateDetails(newUsername, "newhashedpassword", newEmail, "Johnny", "Doe");
        //     // Assert
        //     updateResult.IsSuccess.Should().BeTrue();
        //     user.Username.Should().Be(newUsername);
        //     user.Email.Should().Be(newEmail);
        // }
        
        [TestMethod]
        public void CreateUser_ShouldSucceed_WhenPasswordIsHashedAndSalted()
        {
            // Arrange
            const string  username = "johndoe";
            const string  password = "password123@AAA";
            const string  email = "john.doe@example.com";
            const string  firstName = "John";
            const string  lastName = "Doe";
            // Act
            var result = User.Create(username, password, email, firstName, lastName);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.PasswordHash.Should().NotBeNullOrEmpty();
            result.Value.PasswordSalt.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public void VerifyPassword_ShouldReturnTrue_WhenPasswordMatches()
        {
            // Arrange
            const string  username = "johndoe";
            const string  password = "password123@AAA";
            const string  email = "john.doe@example.com";
            const string  firstName = "John";
            const string  lastName = "Doe";

            var userResult = User.Create(username, password, email, firstName, lastName);
            var user = userResult.Value;
            // Act
            var isValid = user.VerifyPassword(password);
            // Assert
            isValid.Should().BeTrue();
        }

        [TestMethod]
        public void VerifyPassword_ShouldReturnFalse_WhenPasswordDoesNotMatch()
        {
            // Arrange
            const string   username = "johndoe";
            const string   password = "password123@AAA";
            const string   incorrectPassword = "wrongpassword123AAAA@";
            const string   email = "john.doe@example.com";
            const string   firstName = "John";
            const string   lastName = "Doe";

            var userResult = User.Create(username, password, email, firstName, lastName);
            var user = userResult.Value;
            // Act
            var isValid = user.VerifyPassword(incorrectPassword);
            // Assert
            isValid.Should().BeFalse();
        }
    }
}