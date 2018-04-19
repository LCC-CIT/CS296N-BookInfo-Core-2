using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookInfo.Models;
using BookInfo.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookInfo.Controllers
{
    public class AuthorController : Controller
    {
        private IAuthorRepository authorRepo;
        private IBookRepository bookRepo;

        public AuthorController(IAuthorRepository ap, IBookRepository bp)
        {
            authorRepo = ap;
            bookRepo = bp;
        }

        /* Action methods */
        
        public ViewResult Index()
        {
            var authors = authorRepo.GetAllAuthors();
            return View(authors);
        }
        
        
        
        [HttpPost]
        [Authorize]
        public RedirectToActionResult Add(string name, DateTime date, int bookId)
        {
            Book book = bookRepo.GetBookById(bookId);
            Author author = new Author { Name = name, Birthday = date };
            authorRepo.Add(author);
            book.Authors.Add(author);
            bookRepo.Edit(book);
            return RedirectToAction("Index", "Book");
        }

        [HttpGet]
        public ViewResult Edit (int id)
        {
            return View("AuthorEntry", authorRepo.GetAuthorById(id));
        }

        [HttpPost]
        public RedirectToActionResult Edit(String name, DateTime date, int authorid, int bookid)
        {
            Author author = new Author { Name = name, Birthday = date, 
                AuthorID = authorid};

            Book book = bookRepo.GetBookById(bookid);
            book.Authors.Add(author);  // TODO: Check to see if this author is already in the list!

            authorRepo.Edit(author);
            return RedirectToAction("Index");
        }

        public RedirectToActionResult Delete(int id)
        {
            authorRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
