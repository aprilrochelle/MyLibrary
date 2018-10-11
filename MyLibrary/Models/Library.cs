using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.Models
{
    public class Library
    {
        [Key]
        public int LibraryId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string OpenHour { get; set; }

        public string CloseHour { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public virtual ICollection<Library> Libraries { get; set; }
    }
}
