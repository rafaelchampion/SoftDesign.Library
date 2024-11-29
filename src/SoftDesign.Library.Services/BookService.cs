using SoftDesign.Library.Domain.Entities.Books;
using SoftDesign.Library.Domain.Interfaces.Services;
using System.Collections.Generic;
using System;
using SoftDesign.Library.Domain.Interfaces.Repositories;
using System.Linq;
using SoftDesign.Library.Domain.Entities.Users;

namespace SoftDesign.Library.Services
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<User> _userRepository;

        public BookService(IRepository<Book> bookRepository, IRepository<User> userRepository)
        {
            _bookRepository = bookRepository;
            _userRepository = userRepository;
        }

        public IEnumerable<Book> GetBooks(string search = null)
        {
            var query = _bookRepository.GetAll();

            if (!string.IsNullOrEmpty(search))
                query = query.Where(b => b.Title.Contains(search) || b.Author.Contains(search));

            return query.ToList();
        }

        public void RentBook(int bookId, int userId, DateTime rentalDate, DateTime expectedReturnDate)
        {
            var book = _bookRepository.GetById(bookId);
            var user = _userRepository.GetById(userId);

            if (book == null || user == null)
                throw new InvalidOperationException("Invalid book or user.");

            user.RentBook(book, rentalDate, expectedReturnDate);
            _bookRepository.Update(book);
        }
    }
}