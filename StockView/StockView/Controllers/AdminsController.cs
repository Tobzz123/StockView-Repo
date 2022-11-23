using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StockView.Data;
using StockView.Models;

namespace StockView.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly StockviewDataContext _stockviewcontext;


        public AdminsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admins
        public async Task<IActionResult> Index()
        {
           return null; // View(await _context.Admins.ToListAsync());
        }

        public IActionResult UpdateUserWatchlist(Guid id)
        {
            return View();
        }

        
        public IActionResult GetUserId(string email)
        {
            var userId = from u in _context.Users
                         where u.Email == email
                         select u.Id;
            return View();
        }

        //Deletes user's watchlist with ID email
        public IActionResult DeleteUserWatchlist(string email)
        {
            return View();
        }
        // GET: Admins/Details/5
        /*  public async Task<IActionResult> Details(int? id)
          {
              if (id == null)
              {
                  return View("Error", new ErrorViewModel
                  {
                      RequestId = id.ToString(),
                      Description = $"Unable to find admin with id={id}"
                  });
              }

              var admins = await _context.Admins
                  .FirstOrDefaultAsync(m => m.AdminId == id);
              if (admins == null)
              {
                  return NotFound();
              }

              return View(admins);
          }*/

        // GET: Admins/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdminId,Email,FirstName,LastName,AdminUserName,AdminUserRole")] Admins admins)
        {
            if (ModelState.IsValid)
            {
                _context.Add(admins);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(admins);
        }

        // GET: Admins/Edit/5
        /*   public async Task<IActionResult> Edit(int? id)
           {
               if (id == null)
               {
                   return NotFound();
               }

            *//*   var admins = await _context.Admins.FindAsync(id);
               if (admins == null)
               {
                   return NotFound();
               }
               return View(admins);*//*
           }*/

        // POST: Admins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AdminId,Email,FirstName,LastName,AdminUserName,AdminUserRole")] Admins admins)
        {
            if (id != admins.AdminId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(admins);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    /*if (!AdminsExists(admins.AdminId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }*/
                }
                return RedirectToAction(nameof(Index));
            }
            return View(admins);
        }

        // GET: Admins/Delete/5
        /*  public async Task<IActionResult> Delete(int? id)
          {
              if (id == null)
              {
                  return NotFound();
              }

              var admins = await _context.Admins
                  .FirstOrDefaultAsync(m => m.AdminId == id);
              if (admins == null)
              {
                  return NotFound();
              }

              return View(admins);
          }

          // POST: Admins/Delete/5
          [HttpPost, ActionName("Delete")]
          [ValidateAntiForgeryToken]
          public async Task<IActionResult> DeleteConfirmed(int id)
          {
              var admins = await _context.Admins.FindAsync(id);
              _context.Admins.Remove(admins);
              await _context.SaveChangesAsync();
              return RedirectToAction(nameof(Index));
          }

          private bool AdminsExists(int id)
          {
              return _context.Admins.Any(e => e.AdminId == id); ;
          }
      }*/
    }
}
