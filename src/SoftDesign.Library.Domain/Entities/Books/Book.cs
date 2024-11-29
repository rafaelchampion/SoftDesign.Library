using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using SoftDesign.Library.Domain.Entities.Core;
using SoftDesign.Library.Domain.Entities.Rentals;

namespace SoftDesign.Library.Domain.Entities.Books
{
    public partial class Book : BaseEntity
    {
        #region === PROPERTIES ===
        
        public string Title { get; }
        public string Author { get; }
        public string Isbn { get; }
        [NotMapped]
        public bool IsRented => BookRentals.Any(x => x.ActualReturnDate == null);
        [NotMapped]
        public DateTime? LastRentedDate => BookRentals.Max(x => x.RentalDate);
        [NotMapped]
        public DateTime? LastReturnDate => BookRentals.Max(x => x.ActualReturnDate);
        
        #endregion

        #region === RELATIONSHIPS ===
       
        protected virtual ICollection<Rental> BookRentals { get; private set; } = new List<Rental>();

        #endregion

        #region === CONSTRUCTORS ===
        
        private Book() // FOR EF
        {
        } 
        private Book(string title, string author, string isbn)
        {
            Title = title;
            Author = author;
            Isbn = isbn;
        }
        
        #endregion
    }
}