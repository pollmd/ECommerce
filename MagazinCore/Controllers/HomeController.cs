using MagazinCore.Common.Enums;
using MagazinCore.Data;
using MagazinCore.Models;
using MagazinCore.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

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

            var cos = _context.Cos.FirstOrDefault(x=>x.Status == OrderStatus.Draft && x.UserName == User.Identity.Name);
                if (cos != null)
                    ViewBag.NrProduse = _context.CosElemente.Where(x => x.CosId == cos.Id).Count();
                else
                    ViewBag.NrProduse = 0;
            
            
            return View(_context.Produs.ToList());
        }

        public async Task<IActionResult> CumparaAsync(int id)
        {
            var cos = new Cos();

            if (!User.Claims.Any())
            {
                return LocalRedirect("/Identity/Account/Login");
            }
            else
            {
                cos = _context.Cos.FirstOrDefault(e => e.Status == OrderStatus.Draft && e.UserName == User.Identity.Name);
            }

            if (cos == null)
            {
                cos = new Cos();
                cos.Status = OrderStatus.Draft;
                cos.UserName = User.Identity.Name;
                cos.Creare = new DateTime(); //Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));

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

        [HttpPost]
        public async Task<IActionResult> Index(SearchParams searchparams)
        {
            var list = _context.Produs.Where(x => x.Descriere.ToLower().Contains(searchparams.SearchText.ToLower()));

            if (searchparams.Promotion)
            {
                list = list.Where(x => x.Reducere > 0 && x.EndReducere > DateTime.Now && x.StartReducere < DateTime.Now);
            }

            return View(list);
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
