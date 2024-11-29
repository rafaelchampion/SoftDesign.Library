using System.Collections.Generic;
using SoftDesign.Library.Cross.Core.Security;
using SoftDesign.Library.Domain.Entities.Core;
using SoftDesign.Library.Domain.Entities.Rentals;

namespace SoftDesign.Library.Domain.Entities.Users
{
    public partial class User : BaseEntity
    {
        #region === PROPERTIES ===

        public string Username { get; private set; }
        public string PasswordHash { get; private set; }
        public string PasswordSalt { get; private set; }
        public string Email { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        #endregion
        
        #region === RELATIONSHIPS ===

        public virtual ICollection<Rental> UserRentals { get; set; } = new List<Rental>();

        #endregion
        
        #region === CONSTRUCTORS ===

        private User()//FOR EF
        {
        }

        private User(string username, string password, string email)
        {
            var hashedPasswordAndSalt = PasswordHasher.HashPassword(password);
            Username = username;
            PasswordHash = hashedPasswordAndSalt.Password;
            PasswordSalt = hashedPasswordAndSalt.Salt;
            Email = email;
        }
        
        private User(string username, string password, string email, string firstName, string lastName)
        {
            var hashedPasswordAndSalt = PasswordHasher.HashPassword(password);
            Username = username;
            PasswordHash = hashedPasswordAndSalt.Password;
            PasswordSalt = hashedPasswordAndSalt.Salt;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
        }

        #endregion
    }
}