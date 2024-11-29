using SoftDesign.Library.Cross.Core.Results;

namespace SoftDesign.Library.Domain.Entities.Users
{
    public static class UserValidator
    {
        internal static DomainResult Validate(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Username))
                return DomainResult.Failure("Username cannot be empty.");
            if (user.Username.Length > 50)
                return DomainResult.Failure("Username cannot exceed 50 characters.");
            if (string.IsNullOrWhiteSpace(user.PasswordHash))
                return DomainResult.Failure("Password cannot be empty.");
            if (string.IsNullOrWhiteSpace(user.Email) || !user.Email.Contains("@"))
                return DomainResult.Failure("Invalid email format.");
            return DomainResult.Success();
        }
    }
}