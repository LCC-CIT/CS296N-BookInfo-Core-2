using System;
using Microsoft.AspNetCore.Mvc;
using BookInfo.Repositories;
using BookInfo.Models;

namespace BookInfo.Controllers
{
    public class BookController : Controller
    {
        private IBookRepository bookRepo;

        public BookController(IBookRepository bookRepo)
        {
            this.bookRepo = bookRepo;
        }

        // GET: /<controller>/
        public ViewResult Index()
        {
            var books = bookRepo.GetAllBooks();
            return View(books);
        }

        public ViewResult AuthorsOfBook(Book book)
        {
            return View(bookRepo.GetAuthorsByBook(book));
        }

        public ViewResult BooksByAuthor(Author author)
        {
            return View(bookRepo.GetBooksByAuthor(author));
        }

        public ViewResult BookByTitle(string title)
        {
            return View(bookRepo.GetBookByTitle(title));
        }

        [HttpGet]
        public ViewResult AddBook()
        {
            return View();
        }

        [HttpPost]
        public RedirectToActionResult AddBook(String title, String date, String author1, String author2)
        {
            Book book = new Book { Title = title, Date = DateTime.Parse(date) };
            book.Authors.Add(new Author { Name = author1 });
            book.Authors.Add(new Author { Name = author2 });

            bookRepo.AddBook(book);

            return RedirectToAction("Index");
        }

    }
}
