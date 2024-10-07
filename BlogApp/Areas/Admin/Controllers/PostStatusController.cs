using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Blog.Domain.Entities;
using BlogApp.Data;
using BlogApp.Utilities;
using Microsoft.AspNetCore.Authorization;

namespace BlogApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Constans.RoleAdmin)]
    public class PostStatusController : Controller
    {
        private readonly ApplicationContext _context;

        public PostStatusController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: PostStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.PostStatuses.ToListAsync());
        }

        // GET: PostStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postStatus = await _context.PostStatuses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postStatus == null)
            {
                return NotFound();
            }

            return View(postStatus);
        }

        // GET: PostStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PostStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StatusName")] PostStatus postStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(postStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(postStatus);
        }

        // GET: PostStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postStatus = await _context.PostStatuses.FindAsync(id);
            if (postStatus == null)
            {
                return NotFound();
            }
            return View(postStatus);
        }

        // POST: PostStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StatusName")] PostStatus postStatus)
        {
            if (id != postStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostStatusExists(postStatus.Id))
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
            return View(postStatus);
        }

        // GET: PostStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postStatus = await _context.PostStatuses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postStatus == null)
            {
                return NotFound();
            }

            return View(postStatus);
        }

        // POST: PostStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var postStatus = await _context.PostStatuses.FindAsync(id);
            if (postStatus != null)
            {
                _context.PostStatuses.Remove(postStatus);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostStatusExists(int id)
        {
            return _context.PostStatuses.Any(e => e.Id == id);
        }
    }
}
