using SoftDesign.Library.Cross.Core.RequestModels.Rental;
using SoftDesign.Library.Cross.Core.Results;
using SoftDesign.Library.Domain.Entities.Rentals;
using SoftDesign.Library.Domain.Entities.Users;
using SoftDesign.Library.Domain.Interfaces.Repositories;
using SoftDesign.Library.Domain.Interfaces.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using SoftDesign.Library.Cross.Core.ResponseModels.Rental;

namespace SoftDesign.Library.Services.Services
{
    public class RentalService : IRentalService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IRepository<User> _userRepository;

        public RentalService(IBookRepository bookRepository, IRepository<User> userRepository)
        {
            _bookRepository = bookRepository;
            _userRepository = userRepository;
        }

        private static RentalResponse ConvertToRentalResponse(Rental rental)
        {
            return new RentalResponse
            {
                ActualReturnDate = rental.ActualReturnDate,
                ExpectedReturnDate = rental.ExpectedReturnDate,
                RentalDate = rental.RentalDate,
                RenterUsername = rental.User?.Username ?? string.Empty
            };
        }

        public async Task<Result<RentalResponse>> RentBook(RentalRequestModel model)
        {
            var book = await _bookRepository.ReadWithParametersIncluding(x => x.Id == model.BookId, x => x.BookRentals.Select(y => y.User));
            if (book == null)
            {
                return Result<RentalResponse>.Failure("Book not found");
            }
            var user = await _userRepository.ReadWithParametersIncluding(x => x.Id == model.UserId);
            if (user == null)
            {
                return Result<RentalResponse>.Failure("User not found");
            }
            try
            {
                var rentResult = book.Rent(user, DateTime.Now, DateTime.Now.AddDays(7));
                if (!rentResult.IsSuccess)
                {
                    return Result<RentalResponse>.Failure(rentResult.ErrorMessage);
                }
                await _bookRepository.Update(book);
                var lastRental = book.LastRental;
                return Result<RentalResponse>.Success(ConvertToRentalResponse(lastRental));
            }
            catch (Exception ex)
            {
                return Result<RentalResponse>.Failure(ex.Message);
            }
        }

        public async Task<Result<RentalResponse>> ReturnBook(long bookId)
        {
            var book = await _bookRepository.ReadWithParametersIncluding(x => x.Id == bookId, x => x.BookRentals.Select(y => y.User));
            if (book == null)
            {
                return Result<RentalResponse>.Failure("Book not found");
            }

            try
            {
                book.LastUnreturnedRental.ReturnBook(DateTime.Now);
                await _bookRepository.Update(book);
                var lastRental = book.LastUnreturnedRental;
                return Result<RentalResponse>.Success(ConvertToRentalResponse(lastRental));
            }
            catch (Exception ex)
            {
                return Result<RentalResponse>.Failure(ex.Message);
            }
        }
    }
}