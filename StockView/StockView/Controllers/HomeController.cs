using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StockView.Models;

namespace StockView.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            try
            {
                return View();
            }catch(Exception ex)
            {
                return View("Error",
            new ErrorViewModel
            {
                RequestId = ex.ToString(),
                Description = "Error." + ex.Message
            });
            }
        }
        [Authorize]
        public IActionResult Privacy()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return View("Error",
            new ErrorViewModel
            {
                RequestId = ex.ToString(),
                Description = "Error." + ex.Message
            });
            }
        }

        public IActionResult About()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return View("Error",
            new ErrorViewModel
            {
                RequestId = ex.ToString(),
                Description = "Error." + ex.Message
            });
            }
        }

        public IActionResult Chat()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return View("Error",
            new ErrorViewModel
            {
                RequestId = ex.ToString(),
                Description = "Error." + ex.Message
            });
            }
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
