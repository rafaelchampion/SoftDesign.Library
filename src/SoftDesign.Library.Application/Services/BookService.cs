using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SoftDesign.Library.Cross.Core.ResponseModels.Book;
using SoftDesign.Library.Cross.Core.ResponseModels.Rental;
using SoftDesign.Library.Cross.Core.Results;
using SoftDesign.Library.Domain.Entities.Books;
using SoftDesign.Library.Domain.Interfaces.Repositories;
using SoftDesign.Library.Domain.Interfaces.Services;

namespace SoftDesign.Library.Services.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        private static BookResponse ConvertToBookResponse(Book book)
        {
            return new BookResponse
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Isbn = book.Isbn,
                IsRented = book.IsRented,
                RenterUsername = book.LastRental?.User?.Username,
                RentalHistory = book.BookRentals?.Select(r => new RentalResponse
                {
                    RenterUsername = r.User?.Username,
                    RentalDate = r.RentalDate,
                    ExpectedReturnDate = r.ExpectedReturnDate,
                    ActualReturnDate = r.ActualReturnDate
                }).ToList()
            };
        }

        public async Task<Result<int>> CountTotal()
        {
            var query = await _bookRepository.Count();
            return Result<int>.Success(query);
        }

        public async Task<Result<BookResponse>> Create(BookResponse bookModel)
        {
            var bookResult = Book.Create(bookModel.Title, bookModel.Author, bookModel.Isbn);
            if (!bookResult.IsSuccess)
            {
                return Result<BookResponse>.Failure(bookResult.ErrorMessage);
            }
            await _bookRepository.Create(bookResult.Value);
            return Result<BookResponse>.Success(ConvertToBookResponse(bookResult.Value));
        }

        public async Task<Result<BookResponse>> Get(long id)
        {
            var query = await _bookRepository.ReadWithParametersAsNoTrackingIncluding(x => x.Id == id, x => x.BookRentals.Select(y => y.User));
            if (query == null)
            {
                return Result<BookResponse>.Failure("Book not found");
            }
            var data = ConvertToBookResponse(query);
            return Result<BookResponse>.Success(data);
        }

        public async Task<Result<IEnumerable<BookResponse>>> GetAll(string searchQuery)
        {
            searchQuery = searchQuery.Trim();
            IList<Book> query = null;
            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                query = await _bookRepository.ReadAllWithParametersAsNoTrackingIncluding(x =>
                    x.Title.ToLower().Contains(searchQuery.ToLower()) ||
                    x.Author.ToLower().Contains(searchQuery.ToLower()) ||
                    x.Isbn.ToLower().Contains(searchQuery.ToLower()), x => x.BookRentals.Select(y => y.User));
            }
            else
            {
                query = await _bookRepository.ReadAllAsNoTrackingIncluding(x => x.BookRentals.Select(y => y.User));
            }
            try
            {
                var data = query?.Select(ConvertToBookResponse);
                return Result<IEnumerable<BookResponse>>.Success(data);
            }
            catch (System.Exception ex)
            {
                return Result<IEnumerable<BookResponse>>.Failure(ex.Message);
            }
        }

        public async Task<Result<BookResponse>> UpdateDetails(BookResponse bookModel)
        {
            var book = await _bookRepository.ReadWithParametersIncluding(x => x.Id == bookModel.Id, x => x.BookRentals.Select(y => y.User));
            if (book == null)
            {
                return Result<BookResponse>.Failure("Book not found");
            }
            var titleUpdateResult = book.UpdateTitle(bookModel.Title);
            if (!titleUpdateResult.IsSuccess)
            {
                return Result<BookResponse>.Failure(titleUpdateResult.ErrorMessage);
            }
            book = titleUpdateResult.Value;
            var authorUpdateResult = book.UpdateAuthor(bookModel.Author);
            if (!authorUpdateResult.IsSuccess)
            {
                return Result<BookResponse>.Failure(authorUpdateResult.ErrorMessage);
            }
            book = authorUpdateResult.Value;
            var isbnUpdateResult = book.UpdateISBN(bookModel.Isbn);
            if (!isbnUpdateResult.IsSuccess)
            {
                return Result<BookResponse>.Failure(isbnUpdateResult.ErrorMessage);
            }
            book = isbnUpdateResult.Value;
            await _bookRepository.Update(book);
            return Result<BookResponse>.Success(ConvertToBookResponse(book));
        }

        public async Task<Result<BookResponse>> FeaturedBook()
        {
            var query = await _bookRepository.ReadAllAsNoTracking();
            var random = new Random();
            var index = random.Next(query.Count);
            return Result<BookResponse>.Success(ConvertToBookResponse(query[index]));
        }

        public async Task<Result<BookResponse>> MostRented()
        {
            var result = await _bookRepository.ReadAllWithParametersAsNoTrackingIncluding(x => x.BookRentals.Any(), includes: x => x.BookRentals);
            return Result<BookResponse>.Success(ConvertToBookResponse(result.OrderByDescending(x => x.BookRentals.Count()).Take(1).FirstOrDefault()));
        }

        public async Task<Result<int>> CountRented()
        {
            var result = await _bookRepository.ReadAllWithParametersAsNoTrackingIncluding(x => x.BookRentals.Count(y => y.ActualReturnDate == null) > 0 , includes: x => x.BookRentals);
            return Result<int>.Success(result.Count());
        }
    }
}