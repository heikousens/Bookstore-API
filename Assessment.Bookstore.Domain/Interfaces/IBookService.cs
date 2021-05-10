using Assessment.Bookstore.Domain.Models;
using Assessment.Bookstore.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.Bookstore.Domain.Interfaces
{
    public interface IBookService
    {
        IBookRepository Repository { get; }
        RegisteredBook RegisterBook(DataBook dataBook);
        Book ShowBook(Guid idBook);
        IEnumerable<Book> ShowAllBooks();
        Book UpdateBook(Guid idBook, Book dataBook);
        Book DeleteBook(Guid idBook);

    }
}
