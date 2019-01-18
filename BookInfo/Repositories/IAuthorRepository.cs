﻿using BookInfo.Models;
using System.Collections.Generic;

namespace BookInfo.Repositories
{
    public interface IAuthorRepository
    {
        List<Author> GetAuthorsByBook(Book book);
        List<Author> GetAllAuthors();
        Author GetAuthorByName(string name);
        Author GetAuthorById(int id);
        int Add(Author author);
        int Edit(Author author);
        int Delete(int id);

    }
}
