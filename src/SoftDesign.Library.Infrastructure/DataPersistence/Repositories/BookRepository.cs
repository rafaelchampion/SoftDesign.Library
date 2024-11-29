using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using SoftDesign.Library.Domain.Interfaces.Repositories;
using System.Linq;
using SoftDesign.Library.Domain.Entities.Books;

namespace SoftDesign.Library.Infrastructure.DataPersistence.Repositories
{
    public class BookRepository: IBookRepository
    {
        private readonly SoftDesignLibraryContext _context;

        public BookRepository(SoftDesignLibraryContext context)
        {
            _context = context;
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<IEnumerable<Book>> SearchAsync(string searchTerm)
        {
            return await _context.Books
                .Where(b => 
                    string.IsNullOrEmpty(searchTerm) || 
                    b.Title.Contains(searchTerm) || 
                    b.Author.Contains(searchTerm))
                .ToListAsync();
        }

        public async Task AddAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Book book)
        {
            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}