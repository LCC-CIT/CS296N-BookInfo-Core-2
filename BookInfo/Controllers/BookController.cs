using System;
using Microsoft.AspNetCore.Mvc;
using BookInfo.Repositories;
using BookInfo.Models;

namespace BookInfo.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository bookRepo;

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
        public IActionResult AddBook(string title, string date, string author1, string author2)
        {
            Book book = new Book { Title = title, Date = DateTime.Parse(date) };
            if (author1 != null)
            {
                book.Authors.Add(new Author { Name = author1 });
            }
            if (author2 != null)
            {
                book.Authors.Add(new Author { Name = author2 });
            }

            bookRepo.AddBook(book);

            return RedirectToAction("Index");
        }

    }
}
