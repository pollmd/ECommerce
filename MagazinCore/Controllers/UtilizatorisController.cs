using MagazinCore.Data;
using MagazinCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace MagazinCore.Controllers
{
    public class UtilizatorisController : Controller
    {
        private readonly MagazinCoreContext _context;

        public UtilizatorisController(MagazinCoreContext context)
        {
            _context = context;
        }

        // GET: Utilizatoris
        public async Task<IActionResult> Index()
        {
            return View(await _context.Utilizatori.ToListAsync());
        }

        // GET: Utilizatoris/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Utilizatoris/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Utilizatori utilizator)
        {
            if (ModelState.IsValid)
            {
                var md5 = MD5.Create();
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(utilizator.Parola);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                utilizator.Parola = hashBytes.ToString();

                _context.Add(utilizator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(utilizator);
        }

        // GET: Utilizatoris/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilizatori = await _context.Utilizatori.FindAsync(id);
            if (utilizatori == null)
            {
                return NotFound();
            }
            return View(utilizatori);
        }

        // POST: Utilizatoris/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nume,Parola,Creare,Email,Telefon")] Utilizatori utilizatori)
        {
            if (id != utilizatori.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(utilizatori);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UtilizatoriExists(utilizatori.Id))
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
            return View(utilizatori);
        }

        // GET: Utilizatoris/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilizatori = await _context.Utilizatori
                .FirstOrDefaultAsync(m => m.Id == id);
            if (utilizatori == null)
            {
                return NotFound();
            }

            return View(utilizatori);
        }

        // POST: Utilizatoris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var utilizatori = await _context.Utilizatori.FindAsync(id);
            _context.Utilizatori.Remove(utilizatori);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UtilizatoriExists(int id)
        {
            return _context.Utilizatori.Any(e => e.Id == id);
        }
    }
}
