using System;
using System.Collections.Generic;

namespace ReviewNetCore.ConsoleApplicationEFCoreScaffold.Entities
{
    public partial class Books
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? AuthorId { get; set; }

        public virtual Authors Author { get; set; }
    }
}
