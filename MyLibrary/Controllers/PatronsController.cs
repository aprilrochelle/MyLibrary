using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyLibrary.Data;
using MyLibrary.Models;
using MyLibrary.ViewModels;

namespace MyLibrary.Controllers
{
    public class PatronsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PatronsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Patrons
        public async Task<IActionResult> Index()
        {
            return View(await _context.Patron.ToListAsync());
        }

        // GET: Patrons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patron = await _context.Patron
                .FirstOrDefaultAsync(m => m.PatronId == id);
            if (patron == null)
            {
                return NotFound();
            }
            {
                PatronDetailsViewModel patronDetailsViewModel = new PatronDetailsViewModel(_context, patron);

                return View(patronDetailsViewModel);
            }
           
        }

        // GET: Patrons/Create
        public IActionResult Create()
        {
            PatronCreateViewModel patronCreateViewModel = new PatronCreateViewModel(_context);

            return View(patronCreateViewModel);
        }

        // POST: Patrons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Patron patron)
        {
            if (patron.LibraryId == 0)
            {
                patron.LibraryId = null;
            }

            if (ModelState.IsValid)
            {
                _context.Add(patron);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            {
                PatronCreateViewModel patronCreateViewModel = new PatronCreateViewModel(_context)
                {
                    Patron = patron
                };
                return View(patronCreateViewModel);
            }
            
        }

        // GET: Patrons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patron = await _context.Patron.FindAsync(id);
            if (patron == null)
            {
                return NotFound();
            }
            PatronEditViewModel patronEditViewModel = new PatronEditViewModel(_context, patron);

            return View(patronEditViewModel);
        }

        // POST: Patrons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PatronId,FirstName,LastName,LibraryId")] Patron patron)
        {
            if (id != patron.PatronId)
            {
                return NotFound();
            }

            if (patron.LibraryId == 0)
            {
                patron.LibraryId = null;
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patron);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatronExists(patron.PatronId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            PatronEditViewModel patronEditViewModel = new PatronEditViewModel(_context, patron);
            
            return View(patronEditViewModel);
        }

        // GET: Patrons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patron = await _context.Patron
                .FirstOrDefaultAsync(m => m.PatronId == id);
            if (patron == null)
            {
                return NotFound();
            }

            return View(patron);
        }

        // POST: Patrons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patron = await _context.Patron.FindAsync(id);
            _context.Patron.Remove(patron);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatronExists(int id)
        {
            return _context.Patron.Any(e => e.PatronId == id);
        }
    }
}
