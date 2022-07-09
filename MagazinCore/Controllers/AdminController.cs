using MagazinCore.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagazinCore.Controllers
{
    public class AdminController : Controller
    {
        private readonly MagazinCoreContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public AdminController(MagazinCoreContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public ActionResult Index()
        {
            var users = _context.Users;
            return View(users);
        }

        //public ActionResult Index(string userId)
        //{
        //    var user = _context.Users.Find(userId);
        //    return View();
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddUserRole(string userId, string role)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.Find(userId);
                await _userManager.AddToRoleAsync(user, role);
 
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        public ActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddRole(IdentityRole role)
        {
            ViewBag.Roles = new List<IdentityRole> { new IdentityRole() };
            ViewBag.Roles = _context.Roles.ToList();
            if (ModelState.IsValid)
            {
                role.NormalizedName = role.Name.ToUpper();
                _context.Add(role);
                _context.SaveChangesAsync();
            }

            return View();
        }
    }
}
