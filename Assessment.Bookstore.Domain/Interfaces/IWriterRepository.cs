using Assessment.Bookstore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.Bookstore.Domain.Interfaces
{
    public interface IWriterRepository
    {
        Writer GetWriterById(Guid idWriter);
        void SaveWriter(Writer writer);
        IEnumerable<Writer> GetWriters();
        void DeleteWriter(Writer writer);
        void UpdateWriter(Writer writer);
    }
}
