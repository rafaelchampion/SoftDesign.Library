using System.Data.Entity;
using System.Threading.Tasks;
using SoftDesign.Library.Domain.Interfaces.Repositories;
using SoftDesign.Library.Domain.Entities.Books;
using SoftDesign.Library.Domain.Entities.Rentals;
using System.Linq;

namespace SoftDesign.Library.Infrastructure.DataPersistence.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private new readonly DbContext _context;

        public BookRepository(DbContext context) : base(context)
        {
            _context = context;
        }

        public new async Task Update(Book book)
        {
            var entry = _context.Entry(book);
            if (entry.State == EntityState.Detached)
            {
                _context.Set<Book>().Attach(book);
            }

            entry.State = EntityState.Modified;

            foreach (var rental in book.BookRentals)
            {
                var rentalEntry = _context.Entry(rental);

                if (rentalEntry.State == EntityState.Detached)
                {
                    var existingRental = _context.Set<Rental>().Local.FirstOrDefault(r => r.Id == rental.Id);
                    if (existingRental != null)
                    {
                        _context.Entry(existingRental).State = EntityState.Modified;
                    }
                    else
                    {
                        _context.Set<Rental>().Attach(rental);
                    }
                }
                rentalEntry.State = rental.Id == 0 ? EntityState.Added : EntityState.Modified;
            }

            await _context.SaveChangesAsync();
        }
    }
}