using Microsoft.AspNetCore.Mvc.Rendering;
using MyLibrary.Data;
using MyLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.ViewModels
{
    public class PatronCreateViewModel
    {
        public Patron Patron { get; set; }

        public List<SelectListItem> LibraryOfChoice { get; set; }

        public PatronCreateViewModel(ApplicationDbContext context)
        {

            LibraryOfChoice = context.Library.Select(l =>
            new SelectListItem { Text = l.Name, Value = l.LibraryId.ToString() }).ToList();

            LibraryOfChoice.Insert(0, new SelectListItem
            {
                Text = "No Library Selected",
                Value = "0"
            });
        }
    }
}
