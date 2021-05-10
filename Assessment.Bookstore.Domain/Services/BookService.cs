using Assessment.Bookstore.Domain.Interfaces;
using Assessment.Bookstore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.Bookstore.Domain.Services
{
    public class BookService : IBookService
    {
        public BookService(IBookRepository repository)
        {
            Repository = repository;
        }

        public IBookRepository Repository { get; }

        public RegisteredBook RegisterBook(DataBook dataBook)
        {
            var book = new Book
            {
                Id = Guid.NewGuid(),
                Title = dataBook.Title,
                ISBN = dataBook.ISBN,
                PublishingYear = dataBook.PublishingYear
            };


            Repository.SaveBook(book);

            return new RegisteredBook
            {
                Book = book
            };
        }

        public Book ShowBook(Guid idBook)
        {
            return Repository.GetBookById(idBook);
        }

        public IEnumerable<Book> ShowAllBooks()
        {
            return Repository.GetBooks();
        }

        public Book UpdateBook(Guid idBook, Book dataBook)
        {
            var bookMod = Repository.GetBookById(idBook);

            bookMod.Id = dataBook.Id;
            bookMod.Title = dataBook.Title;
            bookMod.ISBN = dataBook.ISBN;
            bookMod.PublishingYear = dataBook.PublishingYear;

            Repository.UpdateBook(bookMod);

            return bookMod;
        }

        public Book DeleteBook(Guid idBook)
        {
            var book = Repository.GetBookById(idBook);

            Repository.DeleteBook(book);

            return null;
        }
    }
}
