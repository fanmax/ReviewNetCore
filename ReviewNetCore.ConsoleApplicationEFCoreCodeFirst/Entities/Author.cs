using System;
using System.Collections.Generic;
using System.Text;

namespace ReviewNetCore.ConsoleApplicationEFCoreCodeFirst.Entities
{
    public class Author
    {
        public Author()
        {
            
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
