using System.Collections.Generic;
using System.Threading.Tasks;
using SoftDesign.Library.Cross.Core.ResponseModels.Book;
using SoftDesign.Library.Cross.Core.Results;

namespace SoftDesign.Library.Domain.Interfaces.Services
{
    public interface IBookService
    {
        Task<Result<BookResponse>> Create(BookResponse book);
        Task<Result<BookResponse>> Get(long id);
        Task<Result<IEnumerable<BookResponse>>> GetAll(string searchQuery);
        Task<Result<int>> CountTotal();
        Task<Result<BookResponse>> UpdateDetails(BookResponse book);
        Task<Result<BookResponse>> FeaturedBook();
        Task<Result<BookResponse>> MostRented();
        Task<Result<int>> CountRented();
    }
}
