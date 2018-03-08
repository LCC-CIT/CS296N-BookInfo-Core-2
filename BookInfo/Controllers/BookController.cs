using System;
using Microsoft.AspNetCore.Mvc;
using BookInfo.Repositories;
using BookInfo.Models;
using Microsoft.AspNetCore.Authorization;

namespace BookInfo.Controllers
{
    // This class will be instantiated by the MVC framework or by a unit test
    public class BookController : Controller
    {
        private IBookRepository bookRepo;

        public BookController(IBookRepository bookRepo)
        {
            this.bookRepo = bookRepo;
        }

        /* Action Methods that get info from the database */

        [Authorize]
        public ViewResult Index()
        {
            var books = bookRepo.GetAllBooks();
            return View(books);
        }

        /*  // TODO: Provide views for these actions
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
        */
        
        /* Action methods that modify the database */

   
        [Authorize]
        public ViewResult Add()
        {
            return View();
        }

        [HttpPost]
        public RedirectToActionResult Add(string title, string date, string author, string birthdate)
        {
            Book book = new Book { Title = title, Date = DateTime.Parse(date) };
            if (author != null)
            {
                book.Authors.Add(new Author { Name = author, Birthday = DateTime.Parse(birthdate)});
            }

            bookRepo.AddBook(book);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ViewResult Edit (int id)
        {
            return View(bookRepo.GetBookById(id));
        }

        [HttpPost]
        public RedirectToActionResult Edit(Book book)
        {
            bookRepo.Edit(book);
            return RedirectToAction("Index");                
        }

        public RedirectToActionResult Delete(int id)
        {
            bookRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
