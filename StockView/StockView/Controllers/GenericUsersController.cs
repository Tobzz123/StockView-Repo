using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StockView.Data;
using StockView.Models;

namespace StockView.Controllers
{
    public class GenericUsersController : Controller
    {
        private readonly stockviewContext _context;

        public GenericUsersController(stockviewContext context)
        {
            _context = context;
        }

        // GET: GenericUsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.GenericUser.ToListAsync());
        }

        // GET: GenericUsers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genericUser = await _context.GenericUser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (genericUser == null)
            {
                return NotFound();
            }

            return View(genericUser);
        }

        // GET: GenericUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GenericUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GenericUserId,Email,PasswordHash,FirstName,LastName,GenericUserName,GenericUserRole")] GenericUser genericUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(genericUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(genericUser);
        }

        // GET: GenericUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genericUser = await _context.GenericUser.FindAsync(id);
            if (genericUser == null)
            {
                return NotFound();
            }
            return View(genericUser);
        }

        // POST: GenericUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("GenericUserId,Email,PasswordHash,FirstName,LastName,GenericUserName,GenericUserRole")] GenericUser genericUser)
        {
            if (!id.Equals(genericUser.Id))
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(genericUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GenericUserExists(genericUser.Id))
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
            return View(genericUser);
        }

        // GET: GenericUsers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genericUser = await _context.GenericUser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (genericUser == null)
            {
                return NotFound();
            }

            return View(genericUser);
        }

        // POST: GenericUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var genericUser = await _context.GenericUser.FindAsync(id);
            _context.GenericUser.Remove(genericUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GenericUserExists(string id)
        {
            return _context.GenericUser.Any(e => e.Id == id); 
        }
    }
}
