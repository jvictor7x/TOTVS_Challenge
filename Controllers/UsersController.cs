using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using TOTVS_Challenge.Models;

namespace TOTVS_Challenge.Controllers
{
    public class UsersController : Controller
    {
        private readonly TOTVSDbContext _context;

        public UsersController(TOTVSDbContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return _context.Users != null ?
                        View(await _context.Users.ToListAsync()) :
                        Problem("Entity set 'TOTVSDbContext.Users'  is null.");
        }

        // GET: Users/CreateOrEdit
        public IActionResult CreateOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Users());
            else
                return View(_context.Users.Find(id));


        }

        // POST: Users/CreateOrEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit([Bind("UserId,Name,Email,AssignedTasks")] Users user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var users = await _context.Users.FindAsync(id);
            _context.Users.Remove(users);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
