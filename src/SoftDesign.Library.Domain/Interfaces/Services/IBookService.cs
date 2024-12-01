using System.Collections.Generic;
using System.Threading.Tasks;
using SoftDesign.Library.Cross.Core.ResultModels.Book;

namespace SoftDesign.Library.Domain.Interfaces.Services
{
    public interface IBookService
    {
        Task<IEnumerable<BookResult>> GetAll();
    }
}
