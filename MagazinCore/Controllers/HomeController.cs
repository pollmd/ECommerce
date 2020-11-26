using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MagazinCore.Models;
using MagazinCore.Data;
using Microsoft.AspNetCore.Http;

namespace MagazinCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MagazinCoreContext _context;

        public HomeController(MagazinCoreContext context, ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.NrProduse = _context.CosElemente.Count();
            ViewBag.LoggedUser = Request.Cookies["LoggedUser"];
            return View(_context.Produs.ToList());
        }

        public async Task<IActionResult> CumparaAsync(int id)
        {
            var cosElemente = new CosElemente
            {
                Cantitate = 1,
                ProdusId = id,
                CosId = 1
            };

            _context.Add(cosElemente);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Autorizare(Utilizatori user)
        {
            var existingUser = _context.Utilizatori.FirstOrDefault(x=>x.Nume == user.Nume && x.Parola == user.Parola);

            if (existingUser != null)
            {
                CookieOptions option = new CookieOptions();
                option.Expires = DateTime.Now.AddDays(30);

                Response.Cookies.Append("LoggedUser", user.Nume, option);

                return RedirectToAction("Index", "Home");
            }

            ViewBag.EroareDeConectare = "Utilizator sau Parolă greșită!";
            return View("Login");
            
        }

        public IActionResult Logout(Utilizatori user)
        {
            Response.Cookies.Delete("LoggedUser");

            return RedirectToAction("Index", "Home");
        }
    }
}
