using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.Bookstore.Domain.Models
{
    public class Writer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Birthday { get; set; }

        //public IEnumerable<Book> Books { get; set; }

        //public Guid BookId { get; set; }
        public Book Book { get; private set; }

        public bool IsWriter(Guid bookId)
        {
            return Book.Id == bookId;
        }

        public void BindWriter(Book book)
        {
            this.Book = book;
        }
    }
}
