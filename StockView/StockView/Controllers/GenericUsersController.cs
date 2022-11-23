using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StockView.Data;
using StockView.Models;
using PayPalCheckoutSdk.Core;
using PayPalCheckoutSdk.Payments;
using PayPalCheckoutSdk.Orders;
using PayPalHttp;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Stripe;

namespace StockView.Controllers
{
    public class GenericUsersController : Controller
    {
        private readonly StockviewDataContext _context;
        private readonly ApplicationDbContext _appDbContext;


        public ActionResult Index()
        {
            return View();
        }
        public GenericUsersController(StockviewDataContext context)
        {
            _context = context;
        }

      

        // GET: GenericUsers/Create
        public IActionResult Create(string stripeToken)
        {
            var chargeOptions = new ChargeCreateOptions()
            {
                Amount = (long)(Convert.ToDouble(39.99) * 100),
                Currency = "USD",
                Source = stripeToken
              
            };

            var service = new ChargeService();
            Charge charge = service.Create(chargeOptions);

            if (charge.Status == "succeeded")
            {
                return View("Success");
            }
            return View("Failure");
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

       public IActionResult LoadPlans()
        {
            var service = new PlanService();
            var allPlans = service.List().ToList();

            return View(allPlans);
        }

        public IActionResult Upgrade()
        {
            return View();
        }

        public IActionResult SubscribeToPlan(string id)
        {
            var subscriptionOptions = new SubscriptionCreateOptions
            {
                Customer = "cus_GqkLCWvde9wrEr",
                Items = new List<SubscriptionItemOptions>
                {
                    new SubscriptionItemOptions
                    {
                        Plan = id
                    }
                }
            };

            var service = new SubscriptionService();
            Subscription subscription = service.Create(subscriptionOptions);

            if (subscription.Created != null)
            {
                return View("Subscribed");
            }
            return View("NotSubscribed");
        }

        public string SubscriptionChange(string email)
        {
            string result;
            try
            {
                
                var id = (from u in _appDbContext.Users
                          where u.Email == email
                          select new { u.Id }).ToString();


                var userInRole = from r in _appDbContext.UserRoles
                                 where r.UserId == (string)id
                                 select r;

                //If Role isn't Premium, update to Premium
                if (userInRole == null)
                {
                    _appDbContext.Database.ExecuteSqlRaw("INSERT INTO AspNetUserRoles VALUES((SELECT Id FROM AspNetUsers WHERE UserName =" + email + ")," +
                        "(SELECT Id FROM AspNetRoles WHERE[Name] = 'Premium') ");
                    result = "Upgraded to Premium";
                }
                else
                {
                    _appDbContext.Database.ExecuteSqlRaw("DELETE FROM AspNetUserRoles WHERE ((SELECT Id FROM AspNetUsers WHERE UserName =" + email + ") ");
                    result = "Downgraded from Premium";
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            //If Role is Premium, remove from UserRoles table

            //Use email to get user from Users table


            //Use UserId to update
            return result;
        }
    }
}
