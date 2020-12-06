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
    public class SchichtplanController : Controller
    {
        private readonly TonnenDbContext _context;

        public SchichtplanController(TonnenDbContext context)
        {
            _context = context;
        }

        // GET: Schichtplan
        public async Task<IActionResult> Index(Guid? id)
        {
            return View(await _context.Schichtplaene.ToListAsync());
        }

        // GET: Schichtplan/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schichtplan = await _context.Schichtplaene
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schichtplan == null)
            {
                return NotFound();
            }

            return View(schichtplan);
        }

        // GET: Schichtplan/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Schichtplan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SchichtDatum")] Schichtplan schichtplan)
        {
            if (ModelState.IsValid)
            {
                schichtplan.Id = Guid.NewGuid();
                _context.Add(schichtplan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(schichtplan);
        }

        // GET: Schichtplan/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schichtplan = await _context.Schichtplaene.FindAsync(id);
            if (schichtplan == null)
            {
                return NotFound();
            }
            return View(schichtplan);
        }

        // POST: Schichtplan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,SchichtDatum")] Schichtplan schichtplan)
        {
            if (id != schichtplan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(schichtplan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SchichtplanExists(schichtplan.Id))
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
            return View(schichtplan);
        }

        // GET: Schichtplan/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schichtplan = await _context.Schichtplaene
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schichtplan == null)
            {
                return NotFound();
            }

            return View(schichtplan);
        }

        // POST: Schichtplan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var schichtplan = await _context.Schichtplaene.FindAsync(id);
            _context.Schichtplaene.Remove(schichtplan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SchichtplanExists(Guid id)
        {
            return _context.Schichtplaene.Any(e => e.Id == id);
        }

        public ActionResult EditKontrolleur(Guid id)
        {
            var schichtplan = _context.Schichtplaene.Find(id);

            // Die Liste aller Kontrolleure als Auswahl
            ViewBag.Kontrolleure = _context.Kontrolleure.ToList();

            return View(schichtplan);
        }

        public ActionResult ChangeKontrolleur(Guid id, Guid kid)
        {
            var auftrag = _context.Arbeitsauftraege.Find(id);
            var kontrolleur = _context.Kontrolleure.Find(kid);

            auftrag.Kontrolleur = kontrolleur;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    public ActionResult TourStarten(Guid id)
    {
      var schichtplan = _context.Schichtplaene.Find(id);
      
      return View(schichtplan);
    }
  }
}
