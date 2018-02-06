using System;
using Microsoft.AspNetCore.Mvc;
using BookInfo.Repositories;
using BookInfo.Models;

namespace BookInfo.Controllers
{
    public class BookController : Controller
    {
        private IBookRepository bookRepo;
        private IAuthorRepository authRepo;

        public BookController(IBookRepository bookRepo, IAuthorRepository authRepo)
        {
            this.bookRepo = bookRepo;
            this.authRepo = authRepo;
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

    }
}
