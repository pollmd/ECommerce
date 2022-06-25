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
using System.Security.Cryptography;
using MagazinCore.Common.Enums;

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
            ViewBag.LoggedUser = Request.Cookies["LoggedUser"];
            ViewBag.UserRole = Request.Cookies["UserRole"];
            var user = _context.Utilizatori.FirstOrDefault(x => x.Nume == Request.Cookies["LoggedUser"]);

            if (user == null)
            {
                ViewBag.NrProduse = 0;
            }
            else 
            {
                var cos = _context.Cos.FirstOrDefault(x=>x.Status == OrderStatus.Draft && x.UserId == user.Id);
                if (cos != null)
                    ViewBag.NrProduse = _context.CosElemente.Where(x => x.CosId == cos.Id).Count();
                else
                    ViewBag.NrProduse = 0;
            }
            
            return View(_context.Produs.ToList());
        }

        public async Task<IActionResult> CumparaAsync(int id)
        {
            var user = _context.Utilizatori.FirstOrDefault(x => x.Nume == Request.Cookies["LoggedUser"]);
            var cos = new Cos();

            if (user == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                cos = _context.Cos.FirstOrDefault(e => e.Status == OrderStatus.Draft && e.UserId == user.Id);
            }

            if (cos == null)
            {
                cos = new Cos();
                cos.Status = OrderStatus.Draft;
                cos.UserId = user.Id;
                cos.Creare = DateTime.Now;

                _context.Add(cos);
                await _context.SaveChangesAsync();
            }

            var cosElemente = new CosElemente
            {
                Cantitate = 1,
                ProdusId = id,
                CosId = cos.Id
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
            var md5 = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(user.Parola);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            user.Parola = Convert.ToBase64String(hashBytes);

            var existingUser = _context.Utilizatori.FirstOrDefault(x=>x.Nume == user.Nume && x.Parola == user.Parola);

            if (existingUser != null)
            {
                CookieOptions option = new CookieOptions();
                option.Expires = DateTime.Now.AddDays(30);

                Response.Cookies.Append("LoggedUser", existingUser.Nume, option);
                Response.Cookies.Append("UserRole", existingUser.Role.ToString(), option);

                return RedirectToAction("Index", "Home");
            }

            ViewBag.EroareDeConectare = "Utilizator sau Parolă greșită!";
            return View("Login");
            
        }

        public IActionResult Logout(Utilizatori user)
        {
            Response.Cookies.Delete("LoggedUser");
            Response.Cookies.Delete("UserRole");

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Utilizatori utilizator)
        {
            if (ModelState.IsValid)
            {
                var md5 = MD5.Create();
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(utilizator.Parola);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                utilizator.Parola = Convert.ToBase64String(hashBytes);

                _context.Add(utilizator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(utilizator);
        }
    }
}
