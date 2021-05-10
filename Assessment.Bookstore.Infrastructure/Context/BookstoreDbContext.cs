using Assessment.Bookstore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.Bookstore.Infrastructure.Context
{
    public class BookstoreDbContext : DbContext
    {
        public BookstoreDbContext(DbContextOptions<BookstoreDbContext> options) : base(options)
        {

        }

        public DbSet<Writer> Writers { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
