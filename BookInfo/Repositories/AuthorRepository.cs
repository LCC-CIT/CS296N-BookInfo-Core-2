using System;
using System.Collections.Generic;
using System.Linq;
using BookInfo.Models;

namespace BookInfo.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private ApplicationDbContext context;

        public AuthorRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public List<Author> GetAllAuthors()
        {
            List<Author> authors = context.Authors.ToList<Author>();
            return authors;
        }

        public Author GetAuthorByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<Author> GetAuthorsByBook(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
