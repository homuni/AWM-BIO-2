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
    public class ArbeitsauftragController : Controller
    {
        private readonly TonnenDbContext _context;

        public ArbeitsauftragController(TonnenDbContext context)
        {
            _context = context;
        }

        // GET: Arbeitsauftrag
        public async Task<IActionResult> Index(Guid? id)
        {
            // wenn keine id angegeben, dann zeige alle Auftraege
            if (id == null)
                return View(await _context.Arbeitsauftraege.ToListAsync());

            // wenn id angegeben, dann nur die Auftraege, die zum Schichteplan gehören
            return View(await _context.Arbeitsauftraege.Where(x => x.Schichtplan.Id == id).ToListAsync());
        }

        // GET: Arbeitsauftrag/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arbeitsauftrag = await _context.Arbeitsauftraege
                .FirstOrDefaultAsync(m => m.Id == id);
            if (arbeitsauftrag == null)
            {
                return NotFound();
            }

            return View(arbeitsauftrag);
        }

        // GET: Arbeitsauftrag/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Arbeitsauftrag/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] Arbeitsauftrag arbeitsauftrag)
        {
            if (ModelState.IsValid)
            {
                arbeitsauftrag.Id = Guid.NewGuid();
                _context.Add(arbeitsauftrag);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(arbeitsauftrag);
        }

        // GET: Arbeitsauftrag/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            // wenn keine id angegeben, dann zeige alle Auftraege
            if (id == null)
                return View(await _context.Arbeitsauftraege.ToListAsync());

            // wenn id angegeben, dann nur die Auftraege, die zum Schichteplan gehören
            return View(await _context.Arbeitsauftraege.Where(x => x.Schichtplan.Id == id).ToListAsync());
        }

        // POST: Arbeitsauftrag/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id")] Arbeitsauftrag arbeitsauftrag)
        {
            if (id != arbeitsauftrag.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(arbeitsauftrag);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArbeitsauftragExists(arbeitsauftrag.Id))
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
            return View(arbeitsauftrag);
        }

        // GET: Arbeitsauftrag/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arbeitsauftrag = await _context.Arbeitsauftraege
                .FirstOrDefaultAsync(m => m.Id == id);
            if (arbeitsauftrag == null)
            {
                return NotFound();
            }

            return View(arbeitsauftrag);
        }

        // POST: Arbeitsauftrag/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var arbeitsauftrag = await _context.Arbeitsauftraege.FindAsync(id);
            _context.Arbeitsauftraege.Remove(arbeitsauftrag);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArbeitsauftragExists(Guid id)
        {
            return _context.Arbeitsauftraege.Any(e => e.Id == id);
        }
    }
}
