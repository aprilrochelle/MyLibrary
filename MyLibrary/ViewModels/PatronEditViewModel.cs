using Microsoft.AspNetCore.Mvc.Rendering;
using MyLibrary.Data;
using MyLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.ViewModels
{
    public class PatronEditViewModel
    {
        public Patron Patron { get; set; }

        public List<SelectListItem> LibraryOfChoice { get; set; }

        public List<Book> CurrentBooks { get; set; }

        public PatronEditViewModel(ApplicationDbContext context, Patron patron)
        {
            Patron = patron;

            LibraryOfChoice = context.Library.Select(l =>
            new SelectListItem { Text = l.Name, Value = l.LibraryId.ToString() }).ToList();

            LibraryOfChoice.Insert(0, new SelectListItem
            {
                Text = "No Library Selected",
                Value = "0"
            });

            CurrentBooks = context.Book
                .Where(b => b.PatronId == Patron.PatronId)
                .ToList();
        }
    }
}
