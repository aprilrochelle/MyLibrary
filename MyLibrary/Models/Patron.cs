using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.Models
{
    public class Patron
    {
        [Key]
        public int PatronId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Primary Branch")]
        public int? LibraryId { get; set; }

        public Library Library { get; set; }

        public virtual ICollection<Book> BooksCheckedOut { get; set; }
    }
}
