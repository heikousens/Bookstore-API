using Assessment.Bookstore.Domain.Models;
using Assessment.Bookstore.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.Bookstore.Domain.Interfaces
{
    public interface IBindBookService
    {
        //IBookRepository bookRepository { get; }

        //IWriterRepository writerRepository { get; }

        BindBook BindBookToWriter(Guid writerId, Guid bookId);
    }
}
