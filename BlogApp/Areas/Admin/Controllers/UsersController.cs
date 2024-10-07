using BlogApp.Data;
using BlogApp.Models;
using BlogApp.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Constans.RoleAdmin)]
    public class UsersController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public UsersController(ApplicationContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> ListUsers(string message)
        {
            var user = await _context.Users.Select(u => new UserViewModel
            {
                Email = u.Email,
            }).ToListAsync();

            var model = new UserListViewModel();
            model.Users = user;
            model.Message = message;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> MakeAdmin(string email)
        {
            var user = await _context.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
            if (user == null)
            {
                return NotFound();
            }
            await _userManager.AddToRoleAsync(user, Constans.RoleAdmin);
            return RedirectToAction("ListUsers", routeValues: new { Message = "Rol asignado correctamente a " + email });
        }

        [HttpPost]
        public async Task<IActionResult> RemoveAdmin(string email)
        {
            //1) Obtenermos el usuario por email
            var user = await _context.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
            //2) validamos
            if (user == null)
            {
                return NotFound();
            }
            //3) retiramos el rol
            await _userManager.RemoveFromRoleAsync(user, Constans.RoleAdmin);
            return RedirectToAction("ListUsers", routeValues: new { Message = "Rol removido correctamente a" + email });
        }
    }
}
