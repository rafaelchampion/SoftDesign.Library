using SoftDesign.Library.Domain.Entities.Books;
using System.Threading.Tasks;

namespace SoftDesign.Library.Domain.Interfaces.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        new Task Update(Book book);
    }
}