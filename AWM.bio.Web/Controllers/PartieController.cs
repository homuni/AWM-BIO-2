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
    public class PartieController : Controller
    {
        private readonly TonnenDbContext _context;

        public PartieController(TonnenDbContext context)
        {
            _context = context;
        }

        // GET: Partie
        public async Task<IActionResult> Index(Guid? id)

        {
            // wenn keine id angegeben, dann zeige alle Partie
            if (id == null)
                return View(await _context.Partien.ToListAsync());

            // wenn id angegeben, dann nur die Partie, die zur Kunde gehören
            return View(await _context.Partien.Where(x => x.Kunde.Id == id).ToListAsync());
            //return View(await _context.Partien.ToListAsync());
        }

        // GET: Partie/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partie = await _context.Partien
                .FirstOrDefaultAsync(m => m.Id == id);
            if (partie == null)
            {
                return NotFound();
            }

            return View(partie);
        }

        // GET: Partie/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Partie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Adresse,Stellplatznotiz")] Partie partie)
        {
            if (ModelState.IsValid)
            {
                partie.Id = Guid.NewGuid();
                _context.Add(partie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(partie);
        }

        // GET: Partie/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partie = await _context.Partien.FindAsync(id);
            if (partie == null)
            {
                return NotFound();
            }
            return View(partie);
        }

        // POST: Partie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Adresse,Stellplatznotiz")] Partie partie)
        {
            if (id != partie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(partie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartieExists(partie.Id))
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
            return View(partie);
        }

        // GET: Partie/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partie = await _context.Partien
                .FirstOrDefaultAsync(m => m.Id == id);
            if (partie == null)
            {
                return NotFound();
            }

            return View(partie);
        }

        // POST: Partie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var partie = await _context.Partien.FindAsync(id);
            _context.Partien.Remove(partie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartieExists(Guid id)
        {
            return _context.Partien.Any(e => e.Id == id);
        }

    public ActionResult PartieBewerten(Guid id)
    {
      var partie = _context.Partien.Find(id);

      return View(partie);
    }
  }
}
