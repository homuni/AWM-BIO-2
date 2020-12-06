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
    public class BewertungController : Controller
    {
        private readonly TonnenDbContext _context;

        public BewertungController(TonnenDbContext context)
        {
            _context = context;
        }

        // GET: Bewertung
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bewertungen.ToListAsync());
        }

        // GET: Bewertung/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bewertung = await _context.Bewertungen
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bewertung == null)
            {
                return NotFound();
            }

            return View(bewertung);
        }

        // GET: Bewertung/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bewertung/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Code,Notiz,Datum,Foto,FileType,Defekt")] Bewertung bewertung)
        {
            if (ModelState.IsValid)
            {
                bewertung.Id = Guid.NewGuid();
                _context.Add(bewertung);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bewertung);
        }

        // GET: Bewertung/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bewertung = await _context.Bewertungen.FindAsync(id);
            if (bewertung == null)
            {
                return NotFound();
            }
            return View(bewertung);
        }

        // POST: Bewertung/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Code,Notiz,Datum,Foto,FileType,Defekt")] Bewertung bewertung)
        {
            if (id != bewertung.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bewertung);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BewertungExists(bewertung.Id))
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
            return View(bewertung);
        }

        // GET: Bewertung/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bewertung = await _context.Bewertungen
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bewertung == null)
            {
                return NotFound();
            }

            return View(bewertung);
        }

        // POST: Bewertung/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var bewertung = await _context.Bewertungen.FindAsync(id);
            _context.Bewertungen.Remove(bewertung);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BewertungExists(Guid id)
        {
            return _context.Bewertungen.Any(e => e.Id == id);
        }

    public ActionResult TonneBewerten(Guid id)
    {
      var bewertung = _context.Tonnen.Find(id);

      return View(bewertung);
    }
  }
}
