using System;
using System.Collections.Generic;

namespace ReviewNetCore.ConsoleApplicationEFCoreScaffold.Entities
{
    public partial class Authors
    {
        public Authors()
        {
            Books = new HashSet<Books>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Books> Books { get; set; }
    }
}
