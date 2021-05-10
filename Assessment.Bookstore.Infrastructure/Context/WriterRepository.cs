using Assessment.Bookstore.Domain.Interfaces;
using Assessment.Bookstore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assessment.Bookstore.Infrastructure.Context
{
    public class WriterRepository : IWriterRepository
    {
        public BookstoreDbContext BookstoreDb { get; }

        public WriterRepository(BookstoreDbContext bookstoreDb)
        {
            BookstoreDb = bookstoreDb;
        }

        public void SaveWriter(Writer writer)
        {
            BookstoreDb.Writers.Add(writer);
            BookstoreDb.SaveChanges();
        }

        public IEnumerable<Writer> GetWriters()
        {
            return BookstoreDb.Writers.ToList();
        }

        public void DeleteWriter(Writer writer)
        {
            BookstoreDb.Writers.Remove(writer);
            BookstoreDb.SaveChanges();
        }

        public void UpdateWriter(Writer writer)
        {
            BookstoreDb.Writers.Update(writer);
            BookstoreDb.SaveChanges();
        }

        public Writer GetWriterById(Guid idWriter)
        {
            return BookstoreDb.Writers.Find(idWriter);
        }
    }
}
