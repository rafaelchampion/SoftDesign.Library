using System;
using SoftDesign.Library.Domain.Entities.Books;
using SoftDesign.Library.Domain.Entities.Core;
using SoftDesign.Library.Domain.Entities.Users;

namespace SoftDesign.Library.Domain.Entities.Rentals
{
    public partial class Rental : BaseEntity
    {
        #region === PROPERTIES ===

        public long BookId { get; set; }
        public long UserId { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
        public DateTime? ActualReturnDate { get; set; }

        #endregion

        #region === RELATIONSHIPS ===

        public virtual Book Book { get; set; }

        public virtual User User { get; set; }

        #endregion

        #region === CONSTRUCTORS ===

        private Rental()//FOR EF
        {
        }

        private Rental(long bookId, long userId, DateTime rentalDate, DateTime expectedReturnDate)
        {
            BookId = bookId;
            UserId = userId;
            RentalDate = rentalDate;
            ExpectedReturnDate = expectedReturnDate;
        }

        #endregion
    }
}