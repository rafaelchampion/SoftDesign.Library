using SoftDesign.Library.Cross.Core.Results;

namespace SoftDesign.Library.Domain.Entities.Users
{
    public static class UserValidator
    {
        internal static Result Validate(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Username))
                return Result.Failure("Username cannot be empty.");
            if (user.Username.Length > 50)
                return Result.Failure("Username cannot exceed 50 characters.");
            if (string.IsNullOrWhiteSpace(user.PasswordHash))
                return Result.Failure("Password cannot be empty.");
            if (string.IsNullOrWhiteSpace(user.Email) || !user.Email.Contains("@"))
                return Result.Failure("Invalid email format.");
            return Result.Success();
        }
    }
}