using Assessment.Bookstore.Domain.Interfaces;
using Assessment.Bookstore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.Bookstore.Domain.Services
{
    public class WriterService : IWriterService
    {
        public WriterService(IWriterRepository repository)
        {
            Repository = repository;
        }

        public IWriterRepository Repository { get; }

        public RegisteredWriter RegisterWriter(DataWriter dataWriter)
        {
            Writer writer = new Writer
            {
                Id = Guid.NewGuid(),
                Name = dataWriter.Name,
                Email = dataWriter.Email,
                Birthday = dataWriter.Birthday
            };

            var registeredWriter = new RegisteredWriter()
            {
                Writer = writer
            };

            Repository.SaveWriter(writer);

            return registeredWriter;
        }

        public Writer ShowWriter(Guid idWriter)
        {
            return Repository.GetWriterById(idWriter);
        }

        public IEnumerable<Writer> ShowAllWriters()
        {
            return Repository.GetWriters();
        }

        public Writer UpdateWriter(Guid idWriter, Writer dataWriter)
        {
            var writerMod = Repository.GetWriterById(idWriter);

            writerMod.Id = dataWriter.Id;
            writerMod.Name = dataWriter.Name;
            writerMod.Email = dataWriter.Email;
            writerMod.Birthday = dataWriter.Birthday;

            Repository.UpdateWriter(writerMod);

            return writerMod;
        }

        public Writer DeleteWriter(Guid idWriter)
        {
            var writer = Repository.GetWriterById(idWriter);

            Repository.DeleteWriter(writer);

            return null;
        }

    }
}
