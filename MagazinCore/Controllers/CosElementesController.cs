using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MagazinCore.Data;
using MagazinCore.Models;

namespace MagazinCore.Controllers
{
    public class CosElementesController : Controller
    {
        private readonly MagazinCoreContext _context;

        public CosElementesController(MagazinCoreContext context)
        {
            _context = context;
        }

        // GET: CosElementes
        public async Task<IActionResult> Index()
        {
            var magazinCoreContext = _context.CosElemente.Include(c => c.Cos).Include(c => c.Produs);
            return View(await magazinCoreContext.ToListAsync());
        }

        // GET: CosElementes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cosElemente = await _context.CosElemente
                .Include(c => c.Cos)
                .Include(c => c.Produs)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cosElemente == null)
            {
                return NotFound();
            }

            return View(cosElemente);
        }

        // GET: CosElementes/Create
        public IActionResult Create()
        {
            ViewData["CosId"] = new SelectList(_context.Cos, "Id", "Id");
            ViewData["ProdusId"] = new SelectList(_context.Produs, "Denumire", "id");
            return View();
        }

        // POST: CosElementes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cantitate,CosId,ProdusId")] CosElemente cosElemente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cosElemente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CosId"] = new SelectList(_context.Cos, "Id", "Id", cosElemente.CosId);
            ViewData["ProdusId"] = new SelectList(_context.Produs, "Denumire", "id", cosElemente.ProdusId);
            return View(cosElemente);
        }

        // GET: CosElementes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cosElemente = await _context.CosElemente.FindAsync(id);
            if (cosElemente == null)
            {
                return NotFound();
            }
            ViewData["CosId"] = new SelectList(_context.Cos, "Id", "Id", cosElemente.CosId);
            ViewData["ProdusId"] = new SelectList(_context.Produs, "id", "id", cosElemente.ProdusId);
            return View(cosElemente);
        }

        // POST: CosElementes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Cantitate,CosId,ProdusId")] CosElemente cosElemente)
        {
            if (id != cosElemente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cosElemente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CosElementeExists(cosElemente.Id))
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
            ViewData["CosId"] = new SelectList(_context.Cos, "Id", "Id", cosElemente.CosId);
            ViewData["ProdusId"] = new SelectList(_context.Produs, "id", "id", cosElemente.ProdusId);
            return View(cosElemente);
        }

        // GET: CosElementes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cosElemente = await _context.CosElemente
                .Include(c => c.Cos)
                .Include(c => c.Produs)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cosElemente == null)
            {
                return NotFound();
            }

            return View(cosElemente);
        }

        // POST: CosElementes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cosElemente = await _context.CosElemente.FindAsync(id);
            _context.CosElemente.Remove(cosElemente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CosElementeExists(int id)
        {
            return _context.CosElemente.Any(e => e.Id == id);
        }
    }
}
