using SoftDesign.Library.Domain.Entities.Books;
using SoftDesign.Library.Domain.Interfaces.Repositories;
using System.Web.Mvc;

namespace SoftDesign.Library.WebAPI.Controllers
{
    public class BookController : Controller
    {
        private readonly IRepository<Book> _bookRepository;

        public BookController(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public ActionResult Index()
        {
            var books = _bookRepository.GetAll();
            return View(books);
        }
    }
}