using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookInfo.Models
{
    public class Book
    {
        private List<Author> authors = new List<Author>();
        public List<Author> Authors { get { return authors; } }

        private List<Review> reviews = new List<Review>();
        public List<Review> Reviews { get { return reviews; } }

        public int BookID { get; set; }     // PK
        
        public string Title { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }
    }
}
