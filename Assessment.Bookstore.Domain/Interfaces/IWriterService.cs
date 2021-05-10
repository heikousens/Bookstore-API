using Assessment.Bookstore.Domain.Models;
using Assessment.Bookstore.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.Bookstore.Domain.Interfaces
{
    public interface IWriterService
    {
        IWriterRepository Repository { get; }
        RegisteredWriter RegisterWriter(DataWriter dataWriter);
        Writer ShowWriter(Guid idWriter);
        IEnumerable<Writer> ShowAllWriters();
        Writer UpdateWriter(Guid idWriter, Writer dataWriter);
        Writer DeleteWriter(Guid idWriter);
    }
}
