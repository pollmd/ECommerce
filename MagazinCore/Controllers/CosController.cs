using MagazinCore.Common.Enums;
using MagazinCore.Data;
using MagazinCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace MagazinCore.Controllers
{
    public class CosController : Controller
    {
        private readonly MagazinCoreContext _context;

        public CosController(MagazinCoreContext context)
        {
            _context = context;
        }

        // GET: Cos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cos.ToListAsync());
        }

        // GET: Cos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cos = await _context.Cos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cos == null)
            {
                return NotFound();
            }

            return View(cos);
        }

        // GET: Cos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cos cos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cos);
        }

        // GET: Cos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cos = await _context.Cos.FindAsync(id);
            if (cos == null)
            {
                return NotFound();
            }
            return View(cos);
        }

        // POST: Cos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Cos cos)
        {
            if (id != cos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CosExists(cos.Id))
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
            return View(cos);
        }

        // GET: Cos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cos = await _context.Cos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cos == null)
            {
                return NotFound();
            }

            return View(cos);
        }

        // POST: Cos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cos = await _context.Cos.FindAsync(id);
            _context.Cos.Remove(cos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> OrderWorkflow(int id)
        {
            var cos = _context.Cos.FirstOrDefault(x => x.Id == id);

            if (cos.Status == OrderStatus.Draft)
            {
                ViewBag.StepperDraft = "active";
            }

            if (cos.Status == OrderStatus.Payed)
            {
                ViewBag.StepperDraft = "completed";
                ViewBag.StepperPayed = "active";
            }

            if (cos.Status == OrderStatus.Delivered)
            {
                ViewBag.StepperDraft = "completed";
                ViewBag.StepperPayed = "completed";
                ViewBag.StepperDelivered = "active";
            }

            if (cos.Status == OrderStatus.Closed)
            {
                ViewBag.StepperDraft = "completed";
                ViewBag.StepperPayed = "completed";
                ViewBag.StepperDelivered = "completed";
                ViewBag.StepperClosed = "active";
            }

            return View(cos);
        }

        private bool CosExists(int id)
        {
            return _context.Cos.Any(e => e.Id == id);
        }
    }
}
