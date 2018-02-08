using BookInfo.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace BookInfo
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider services)
        {
            ApplicationDbContext context = services.GetRequiredService<ApplicationDbContext>();
            context.Database.EnsureCreated();
            if (!context.Books.Any())
            {
                Book book = new Book { Title = "Lord of the Rings", Date = DateTime.Parse("1/1/1937") }; // month/day/year
                context.Books.Add(book);    // add the book to the dB Context
                context.SaveChanges();      // save it so it gets an ID (PK value)
                Author author = new Author { Name = "J. R. R. Tolkien", BookID = book.BookID};
                context.Authors.Add(author); 
                book.Authors.Add(author);


                book = new Book { Title = "The Lion, the Witch, and the Wardrobe", Date = DateTime.Parse("1/1/1950") };
                context.Books.Add(book);
                context.SaveChanges();
                author = new Author { Name = "C. S. Lewis", BookID = book.BookID };
                context.Authors.Add(author);
                book.Authors.Add(author);

                book = new Book { Title = "Prince of Foxes", Date = DateTime.Parse("1/1/1947") };
                context.Books.Add(book);
                context.SaveChanges();
                author = new Author { Name = "Samuel Shellabarger", BookID = book.BookID };
                context.Authors.Add(author);
                book.Authors.Add(author);

                context.SaveChanges(); // save the last addition
            }
        }
    }
}

/* Code in Initialize is based on:
 * https://dotnetthoughts.net/seed-database-in-aspnet-core/
 */