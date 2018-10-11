using MyLibrary.Data;
using MyLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.ViewModels
{
    public class PatronDetailsViewModel
    {
        public Patron Patron { get; set; }

        public Library CurrentLibrary { get; set; }

        public List<Book> CurrentBooks { get; set; }

        public PatronDetailsViewModel(ApplicationDbContext context, Patron patron)
        {
            Patron = patron;

            CurrentLibrary = patron.Library;

            CurrentBooks = context.Book
                .Where(b => b.PatronId == Patron.PatronId)
                .ToList();
        }
    }
}
