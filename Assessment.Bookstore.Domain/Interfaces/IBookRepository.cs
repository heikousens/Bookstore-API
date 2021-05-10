using Assessment.Bookstore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.Bookstore.Domain.Interfaces
{
    public interface IBookRepository
    {
        Book GetBookById(Guid idBook);
        void SaveBook(Book book);
        IEnumerable<Book> GetBooks();
        void DeleteBook(Book book);
        void UpdateBook(Book book);
    }
}
