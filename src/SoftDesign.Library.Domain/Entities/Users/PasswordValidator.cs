using System.Text.RegularExpressions;
using SoftDesign.Library.Cross.Core.Results;

namespace SoftDesign.Library.Domain.Entities.Users
{
    internal static class PasswordValidator
    {
        internal static Result Validate(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return Result.Failure("Password cannot be empty.");
            if (password.Length < 8)
                return Result.Failure("Password must have at least 8 characters.");
            if (password.Length > 30)
                return Result.Failure("Password must not have more than 30 characters.");
            var uppercaseRegex = new Regex("[A-Z]");
            var lowercaseRegex = new Regex("[a-z]");
            var numberRegex = new Regex("[0-9]");
            var specialCharRegex = new Regex(@"[#?!@$%^&*\-]");

            if (!uppercaseRegex.IsMatch(password))
                return Result.Failure("Password must contain at least 1 uppercase character.");
    
            if (!lowercaseRegex.IsMatch(password))
                return Result.Failure("Password must contain at least 1 lowercase character.");
    
            if (!numberRegex.IsMatch(password))
                return Result.Failure("Password must contain at least 1 number.");
    
            if (!specialCharRegex.IsMatch(password))
                return Result.Failure("Password must contain at least 1 special character (#?!@$%^&*-).");
    
            return Result.Success();
        }
    }
}