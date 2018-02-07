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

        public RedirectToActionResult AddBook()
        {
            Author author1 = new Author
            {
                Name = "Joe Test",
                Birthday = DateTime.Parse("6/1/1950")
            };
            Author author2 = new Author
            {
                Name = "Jane Test",
                Birthday = DateTime.Parse("9/1/1960")
            };
            Book book = new Book
            {
                Title = "Test Title",
                Date = DateTime.Parse("12/1/2000")
            };
            book.Authors.Add(author1);
            book.Authors.Add(author2);

            bookRepo.AddBook(book);

            return RedirectToAction("Index");
        }

    }
}
