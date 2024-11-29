﻿using SoftDesign.Library.Domain.Entities.Books;
using SoftDesign.Library.Domain.Interfaces.Repositories;
using System.Web.Mvc;

namespace SoftDesign.Library.WebAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Book> _bookRepository;
        public HomeController(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public ActionResult Index()
        {
            var books = _bookRepository.GetAll();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}