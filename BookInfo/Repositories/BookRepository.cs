using System;
using System.Collections.Generic;
using System.Linq;
using BookInfo.Models;
using Microsoft.EntityFrameworkCore;

namespace BookInfo.Repositories
{
    // The repository object will be injected into a Controller by a transient service (configured in Startup)
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext context;
 
        public BookRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        
        /* Interface method implementations */

        public List<Book> GetAllBooks()
        {
            return context.Books.Include(b => b.Authors).ToList();
        }

        public Book GetBookByTitle(string title)
        {
            return context.Books.Include(b => b.Authors).First(b => b.Title == title);
        }

        public Book GetBookById(int id)
        {
            return context.Books.Include("Authors").First(b => b.BookID == id);
        }

        public List<Book> GetBooksByAuthor(Author author)
        {
            return (from b in context.Books
                    where b.Authors.Contains(author)
                   select b).Include(b => b.Authors).ToList();
        }

        public List<Author> GetAuthorsByBook(Book book)
        {
            throw new NotImplementedException();
        }

        public int AddBook(Book book)
        {
            // Add the book to the database
            context.Books.Update(book);
            // Save the book so that it gets an ID (primary key value)
            context.SaveChanges();

            // Give each author object a FK for the book
            // and add it to the database
            foreach (Author a in book.Authors)
            {
                a.BookID = book.BookID;
                context.Authors.Update(a);
            }
            
            return context.SaveChanges();
        }
        
        public int Edit(Book book)
        {
            context.Books.Update(book);
            return context.SaveChanges();
        }

        public int Delete(int id)
        {
            var bookFromDb = context.Books.First(a => a.BookID == id);
            context.Remove(bookFromDb);
            return context.SaveChanges();
        }

        // TODO: implement this method
        /*
        public List<Author> GetAuthorsByBook(Book book)
        {
            return context.Books.Authors;
        }
        */
    }
}
