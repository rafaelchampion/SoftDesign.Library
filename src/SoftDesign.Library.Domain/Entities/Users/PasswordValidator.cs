using System.Text.RegularExpressions;
using SoftDesign.Library.Cross.Core.Results;

namespace SoftDesign.Library.Domain.Entities.Users
{
    internal static class PasswordValidator
    {
        private static string pattern = @"^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
        
        internal static Result Validate(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return Result.Failure("Password cannot be empty.");
            if (password.Length < 8)
                return Result.Failure("Password must have at least 8 characters.");
            if (password.Length > 30)
                return Result.Failure("Password must not have more than 30 characters.");
            if (!new Regex(pattern).IsMatch(password))
            {
                return Result.Failure("Password must contain at least 1 uppercase character, 1 number and 1 special character.");
            }
            return Result.Success();
        }
    }
}