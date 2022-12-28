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
    [Authorize(Roles = "Manager")]

    public class ManagersController : Controller
    {
        private readonly StockviewDataContext _context;

        public ManagersController(StockviewDataContext context)
        {
            _context = context;
        }

        // GET: Managers
        public IActionResult Index()
        {

            return View();
        }


        // GET: Managers/Create
        public IActionResult Create()
        {
            return View();
        }




        // GET: Managers/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*  var manager = await _context.Manager
                  .FirstOrDefaultAsync(m => m.ManagerId == id);
              if (manager == null)
              {
                  return NotFound();
              }*/

            return View(/*manager*/);
        }


    }
}
