using System;
using System.Collections.Generic;
using System.Linq;
using BookInfo.Models;
using Microsoft.EntityFrameworkCore;

namespace BookInfo.Repositories
{
    public class BookRepository : IBookRepository
    {
        private ApplicationDbContext context;
 
        public BookRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public List<Book> GetAllBooks()
        {
            return context.Books.Include(b => b.Authors).ToList<Book>();
        }

        public Book GetBookByTitle(string title)
        {
            return context.Books.Include(b => b.Authors).First(b => b.Title == title);
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

        // TODO: implement this method
        /*
        public List<Author> GetAuthorsByBook(Book book)
        {
            return context.Books.Authors;
        }
        */
    }
}
