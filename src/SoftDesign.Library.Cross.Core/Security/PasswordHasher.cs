using System;
using System.Linq;
using System.Security.Cryptography;

namespace SoftDesign.Library.Cross.Core.Security
{
    public class PasswordHasher
    {
        private const int SaltSize = 16;
        private const int HashSize = 32;
        private const int Iterations = 10000;

        public static HashedPassword HashPassword(string password)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var salt = new byte[SaltSize];
                rng.GetBytes(salt);
                using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations))
                {
                    var hash = pbkdf2.GetBytes(HashSize);
                    return new HashedPassword(Convert.ToBase64String(hash), Convert.ToBase64String(salt));
                }
            }
        }

        public static bool VerifyPassword(string password, string storedHash, string storedSalt)
        {
            var salt = Convert.FromBase64String(storedSalt);
            var hash = Convert.FromBase64String(storedHash);
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations))
            {
                var computedHash = pbkdf2.GetBytes(HashSize);
                return AreHashesEqual(computedHash, hash);
            }
        }

        private static bool AreHashesEqual(byte[] computedHash, byte[] storedHash)
        {
            if (computedHash.Length != storedHash.Length)
            {
                return false;
            }
            return !computedHash.Where((t, i) => t != storedHash[i]).Any();
        }
    }
}