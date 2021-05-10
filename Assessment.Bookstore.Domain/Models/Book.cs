using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.Bookstore.Domain.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int PublishingYear { get; set; }

    }
}
