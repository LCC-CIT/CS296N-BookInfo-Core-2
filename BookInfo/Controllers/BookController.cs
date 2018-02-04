using Microsoft.AspNetCore.Mvc;
using BookInfo.Models;
using System.Collections.Generic;
using System;

namespace BookInfo.Controllers
{
    public class BookController : Controller
    {
        // Temporary code: The constructor creates a list of books just for testing
        // Later we'll see a better way to do this!
        List<Book> books = new List<Book>();

        public BookController()
        {
            Book book = new Book { Title = "Lord of the Rings", Date = DateTime.Parse("1/1/1937") }; // month/day/year
            book.Authors.Add(new Author { Name = "J. R. R. Tolkien" });
            books.Add(book);

            book = new Book { Title = "The Lion, the Witch, and the Wardrobe", Date = DateTime.Parse("1/1/1950") };
            book.Authors.Add(new Author { Name = "C. S. Lewis" });
            books.Add(book);

            book = new Book { Title = "Prince of Foxes", Date = DateTime.Parse("1/1/1947") };
            book.Authors.Add(new Author { Name = "Samuel Shellabarger" });
            books.Add(book);
        }

        // GET: /<controller>/
        public ViewResult Index()
        {
            return View(books);
        }

    }
}
