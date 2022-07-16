using MagazinCore.Data;
using MagazinCore.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            var roles = _context.Roles.ToList();
            var userRoles = _context.UserRoles.ToList();

            ViewBag.Roles = new List<SelectListItem>();
            foreach(var item in roles)
            {
                ViewBag.Roles.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Name
                });
            }

            var users = _context.Users;
            var usersWithRoles = new List<UserWithRoles>();

            foreach (var u in users)
            {
                var ur = userRoles.Where(x => x.UserId == u.Id).Select(x => x.RoleId).ToList();
                var uwr = new UserWithRoles
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    Roles = roles.Where(x => ur.Contains(x.Id)).Select(x=>x.Name).ToList()
                };

                usersWithRoles.Add(uwr);
            }
            return View(usersWithRoles);
        }


        [HttpPost]
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
            if (ModelState.IsValid)
            {
                role.NormalizedName = role.Name.ToUpper();
                _context.Add(role);
                _context.SaveChangesAsync();
            }

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> DeleteUserRole(string userId, string role)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.Find(userId);
                await _userManager.RemoveFromRoleAsync(user, role);

                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
