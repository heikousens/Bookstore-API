using Assessment.Bookstore.Domain.Interfaces;
using Assessment.Bookstore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assessment.Bookstore.Infrastructure.Context
{
    public class BookRepository : IBookRepository
    {
        public BookstoreDbContext BookstoreDb { get; }

        public BookRepository(BookstoreDbContext bookstoreDb)
        {
            BookstoreDb = bookstoreDb;
        }

        public void SaveBook(Book book)
        {
            BookstoreDb.Books.Add(book);
            BookstoreDb.SaveChanges();
        }

        public IEnumerable<Book> GetBooks()
        {
            return BookstoreDb.Books.ToList();
        }


        public void DeleteBook(Book book)
        {
            BookstoreDb.Books.Remove(book);
            BookstoreDb.SaveChanges();
        }

        public void UpdateBook(Book book)
        {
            BookstoreDb.Books.Update(book);
            BookstoreDb.SaveChanges();
        }

        public Writer GetWriterById(Guid idWriter)
        {
            return BookstoreDb.Writers.Find(idWriter);
        }
        public Book GetBookById(Guid idBook)
        {
            return BookstoreDb.Books.Find(idBook);
        }
    }
}
