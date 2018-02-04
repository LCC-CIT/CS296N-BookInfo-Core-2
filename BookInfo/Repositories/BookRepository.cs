﻿using System;
using System.Collections.Generic;
using System.Linq;
using BookInfo.Models;

namespace BookInfo.Repositories
{
    public class BookRepository : IBookRepository
    {
        private ApplicationDbContext context;
 
        public BookRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        /*
        List<Book> books = new List<Book>();
        public BookRepository()
        {
            Book book = new Book { Title = "Lord of the Rings", Date = DateTime.Parse("1/1/1937") }; // month/day/year
            book.Authors.Add(new Author { Name = "J. R. R. Tolkien"});
            books.Add(book);

            book = new Book { Title = "The Lion, the Witch, and the Wardrobe", Date = DateTime.Parse("1/1/1950") };
            book.Authors.Add(new Author { Name = "C. S. Lewis" });
            books.Add(book);

            book = new Book { Title = "Prince of Foxes", Date = DateTime.Parse("1/1/1947")};
            book.Authors.Add(new Author { Name = "Samuel Shellabarger" });
            books.Add(book);
        }
        */

        public List<Book> GetAllBooks()
        {
            return context.Books.ToList<Book>();
        }

        public Book GetBookByTitle(string title)
        {
            return context.Books.First(b => b.Title == title);
        }

        public List<Book> GetBooksByAuthor(Author author)
        {
            return (from b in context.Books
                    where b.Authors.Contains(author)
                   select b).ToList();
        }

        public List<Author> GetAuthorsByBook(Book book)
        {
            throw new NotImplementedException();
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
