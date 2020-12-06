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
    public class TonnenController : Controller
    {
        private readonly TonnenDbContext _context;

        public TonnenController(TonnenDbContext context)
        {
            _context = context;
        }

        // GET: Tonnen
        public async Task<IActionResult> Index(Guid? id)
        {
            // wenn keine id angegeben, dann zeige alle Tonnen
            if (id == null)
                return View(await _context.Tonnen.ToListAsync());

            // wenn id angegeben, dann nur die Tonnen, die zur Partie gehören
            return View(await _context.Tonnen.Where(x => x.Partie.Id == id).ToListAsync());
        }

        // GET: Tonnen/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tonne = await _context.Tonnen
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tonne == null)
            {
                return NotFound();
            }

            return View(tonne);
        }

        // GET: Tonnen/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tonnen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Volumen")] Tonne tonne)
        {
            if (ModelState.IsValid)
            {
                tonne.Id = Guid.NewGuid();
                _context.Add(tonne);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tonne);
        }

        // GET: Tonnen/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tonne = await _context.Tonnen.FindAsync(id);
            if (tonne == null)
            {
                return NotFound();
            }
            return View(tonne);
        }

        // POST: Tonnen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Volumen")] Tonne tonne)
        {
            if (id != tonne.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tonne);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TonneExists(tonne.Id))
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
            return View(tonne);
        }

        // GET: Tonnen/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tonne = await _context.Tonnen
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tonne == null)
            {
                return NotFound();
            }

            return View(tonne);
        }

        // POST: Tonnen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tonne = await _context.Tonnen.FindAsync(id);
            _context.Tonnen.Remove(tonne);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TonneExists(Guid id)
        {
            return _context.Tonnen.Any(e => e.Id == id);
        }
    }
}
