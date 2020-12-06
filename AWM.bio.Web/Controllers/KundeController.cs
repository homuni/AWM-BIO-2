using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AWM.bio.Web.Data.AWM;

namespace AWM.bio.Web.Controllers
{
    public class KundeController : Controller
    {
        private readonly TonnenDbContext _context;

        public KundeController(TonnenDbContext context)
        {
            _context = context;
        }

        // GET: Kunde
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kunden.ToListAsync());
        }

        // GET: Kunde/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kunde = await _context.Kunden
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kunde == null)
            {
                return NotFound();
            }

            return View(kunde);
        }

        // GET: Kunde/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kunde/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Vorname,Nachname,KontaktAdresse")] Kunde kunde)
        {
            if (ModelState.IsValid)
            {
                kunde.Id = Guid.NewGuid();
                _context.Add(kunde);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kunde);
        }

        // GET: Kunde/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kunde = await _context.Kunden.FindAsync(id);
            if (kunde == null)
            {
                return NotFound();
            }
            return View(kunde);
        }

        // POST: Kunde/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Vorname,Nachname,KontaktAdresse")] Kunde kunde)
        {
            if (id != kunde.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kunde);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KundeExists(kunde.Id))
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
            return View(kunde);
        }

        // GET: Kunde/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kunde = await _context.Kunden
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kunde == null)
            {
                return NotFound();
            }

            return View(kunde);
        }

        // POST: Kunde/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var kunde = await _context.Kunden.FindAsync(id);
            _context.Kunden.Remove(kunde);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KundeExists(Guid id)
        {
            return _context.Kunden.Any(e => e.Id == id);
        }
    }
}
