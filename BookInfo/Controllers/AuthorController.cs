using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookInfo.Models;
using BookInfo.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookInfo.Controllers
{
    public class AuthorController : Controller
    {
        private IAuthorRepository authorRepo;

        public AuthorController(IAuthorRepository repo)
        {
            authorRepo = repo;
        }

        /* Action methods */
        
        public ViewResult Index()
        {
            var authors = authorRepo.GetAllAuthors();
            return View(authors);
        }
        
        
        
        [HttpPost]
        public RedirectToActionResult Add(string name, DateTime date, int bookId)
        {
            authorRepo.Add(new Author {Name = name, Birthday = date, BookID = bookId});
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
                AuthorID = authorid, BookID = bookid }; 

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
