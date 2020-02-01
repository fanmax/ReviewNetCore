using System;
using System.Collections.Generic;
using System.Text;

namespace ReviewNetCore.ConsoleApplicationEFCoreCodeFirst.Entities
{
    public class Book
    {
        public Book()
        {
            
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? AuthorId { get; set; }

        public virtual Author Author { get; set; }
    }
}
