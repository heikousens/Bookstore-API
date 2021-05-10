using Assessment.Bookstore.Domain.Interfaces;
using Assessment.Bookstore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.Bookstore.Domain.Services
{
    public class BindBookService : IBindBookService
    {
        public BindBookService(IBookRepository bookRepository, IWriterRepository writerRepository)
        {
            BookRepository = bookRepository;
            WriterRepository = writerRepository;
        }

        public IBookRepository BookRepository { get; }

        public IWriterRepository WriterRepository { get; }

        public BindBook BindBookToWriter(Guid writerId, Guid bookId)
        {

            var writer = WriterRepository.GetWriterById(writerId);
            if (writer == null)
            {
                return new BindBook
                {
                    Error = "Writer not found!"
                };
            }

            var book = BookRepository.GetBookById(bookId);

            writer.BindWriter(book);

            return new BindBook
            {
                Writer = writer
            };
        }
    }
}
