using System;
using System.Collections.Generic;

namespace BookInfo.Models
{
    public class Book
    {
        private List<Author> authors = new List<Author>();

        public List<Author> Authors { get { return authors; } }
        public int BookID { get; set; }     // PK
        public string Title { get; set; }
        public DateTime Date { get; set; }
    }
}
