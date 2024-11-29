using System.Linq;

namespace SoftDesign.Library.Domain.Entities.Books
{
    internal static class IsbnValidator
    {
        internal static bool IsValidIsbn(string isbn)
        {
            return isbn.All(char.IsDigit) && (isbn.Length == 13 || isbn.Length == 10);
        }
    }
}