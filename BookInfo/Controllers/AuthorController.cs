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

        public ViewResult Index()
        {
            var authors = authorRepo.GetAllAuthors();
            return View(authors);
        }
        
        [HttpGet]
        public ViewResult Add()
        {
            // Just send an empty Author object so that the form input values won't be null
            return View("AuthorEntry", new Author());
        }

        [HttpPost]
        public IActionResult Add(string name, DateTime date)
        {
            Author author = new Author { Name = name, Birthday = date };

            authorRepo.Add(author);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ViewResult Edit (int id)
        {
            return View("AuthorEntry", authorRepo.GetAuthorById(id));
        }

        [HttpPost]
        public IActionResult Edit(String name, DateTime date, int authorid, int bookid)
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
