using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.Bookstore.Domain.Models
{
    public class DataWriter
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Birthday { get; set; }
    }
}
