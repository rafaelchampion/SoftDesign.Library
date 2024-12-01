using SoftDesign.Library.Cross.Core.RequestModels.Rental;
using SoftDesign.Library.Cross.Core.Results;
using System.Threading.Tasks;
using SoftDesign.Library.Cross.Core.ResponseModels.Rental;

namespace SoftDesign.Library.Domain.Interfaces.Services
{
    public interface IRentalService
    {
        Task<Result<RentalResponse>> RentBook(RentalRequestModel model);
        Task<Result<RentalResponse>> ReturnBook(long bookId);
    }
}
