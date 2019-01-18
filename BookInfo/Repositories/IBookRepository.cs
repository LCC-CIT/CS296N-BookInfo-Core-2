using BookInfo.Models;
using System.Collections.Generic;

namespace BookInfo.Repositories
{
    public interface IBookRepository
    {
        List<Book> GetAllBooks();
        Book GetBookByTitle(string title);
        Book GetBookById(int id);
        List<Book> GetBooksByAuthor(Author author);
        List<Author> GetAuthorsByBook(Book book);
        int AddBook(Book book);
        int Edit(Book book);
        int Delete(int id);
    }
}
