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
            ViewBag.NrProduse = _context.CosElemente.Count();
            var magazinCoreContext = _context.CosElemente.Include(c => c.Cos).Include(c => c.Produs);
            return View(await magazinCoreContext.ToListAsync());
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
