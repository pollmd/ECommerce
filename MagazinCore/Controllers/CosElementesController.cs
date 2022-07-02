using MagazinCore.Common.Enums;
using MagazinCore.Data;
using MagazinCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

            var user = new { Id = ""};
            var produse = _context.CosElemente.Where(x => x.CosId == -1);

            if (user == null)
            {
                ViewBag.NrProduse = 0;
            }
            else
            {
                var cos = _context.Cos.FirstOrDefault(x => x.Status == OrderStatus.Draft);
                if (cos != null)
                {
                    ViewBag.NrProduse = _context.CosElemente.Where(x => x.CosId == cos.Id).Count();
                    produse = _context.CosElemente.Include(c => c.Cos).Include(c => c.Produs).Where(x=>x.CosId==cos.Id);
                }
                else
                    ViewBag.NrProduse = 0;
            }

            

            return View(await produse.ToListAsync());
        }

        // GET: CosElementes
        public IActionResult OrdinDeplata()
        {
            ViewBag.NrProduse = _context.CosElemente.Count();
            var produse = _context.CosElemente.Include(c => c.Cos).Include(c => c.Produs);

            ViewBag.SumaTotala = produse.Sum(x => x.Produs.Cost);

            var produseGrupate = new List<CosElemente>();

            foreach (var line in produse.GroupBy(info => info.Produs.id)
                        .Select(group => new
                        {
                            Metric = group.Key,
                            Count = group.Count()
                        })
                        .OrderBy(x => x.Metric))
            {
                produseGrupate.Add(new CosElemente
                {
                    Produs = _context.Produs.Find(line.Metric),
                    Cantitate = line.Count
                });
            }

            return View(produseGrupate);
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

        public async Task<IActionResult> AchitaAsync()
        {

            var user = new { Id = "" };

            if (user != null)
            {
                ViewBag.NrProduse = 0;

                var cos = _context.Cos.FirstOrDefault(x => x.Status == OrderStatus.Draft);

                if (cos != null)
                {
                    cos.Status = OrderStatus.Payed;
                    _context.Cos.Update(cos);

                    var elemente = _context.CosElemente.Include(p=>p.Produs).Where(x => x.CosId == cos.Id);
                    foreach(var e in elemente)
                    {
                        e.Produs.Cantitate = e.Produs.Cantitate - 1;
                        _context.Produs.Update(e.Produs);
                    }

                    await _context.SaveChangesAsync();
                }
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
