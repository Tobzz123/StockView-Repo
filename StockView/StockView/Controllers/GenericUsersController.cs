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

namespace StockView.Controllers
{
    public class GenericUsersController : Controller
    {
        private readonly stockviewContext _context;
        #region ClientID_and_secret
        private String _paypalEnvironment = "sandbox";
        private String _clientId = "your sandbox app client ID";
        private String _secret = "your sandbox app secret";
        #endregion


        public ActionResult Index()
        {
            return View();
        }
        public GenericUsersController(stockviewContext context)
        {
            _context = context;
        }

        // GET: GenericUsers
        /*   public async Task<IActionResult> Index()
           {
               return View(await _context.GenericUser.ToListAsync());
           }*/

        // GET: GenericUsers/Details/5
        [Authorize]
        public async Task<IActionResult> PaypalCheckout(string Cancel = null)
        {
            MyPaypalPayment.MyPaypalSetup paypalSetup = new MyPaypalPayment.MyPaypalSetup { Environment = _paypalEnvironment, ClientId = _clientId, Secret = _secret };

            List<string> paymentResultList = new List<string>();
           
            //Check if payer cancels transaction: Inform payer about what is going on
            if (!string.IsNullOrEmpty(Cancel) && Cancel.Trim().ToLower() == "true")
            {
                paymentResultList.Add("You cancelled the transaction.");
                return View("Index", paymentResultList);
            }

            //Test this part with different Request properties. Either Form - x, RouteValues, Headers, Query, or QueryString
            paypalSetup.PayerApprovedOrderId = Request.RouteValues["token"].ToString();
            string PayerID = Request.RouteValues["PayerID"].ToString();
            
            //If payerID is null then order is not approved by payer
            if (string.IsNullOrEmpty(PayerID))
            {
                //Order Creation
                try
                {
                    paypalSetup.RedirectUrl = Request.Scheme + "://" + Request.Host + Request.PathBase + "/GenericUsers/PaypalCheckout?";
                    HttpResponse response = await MyPaypalPayment.CreateOrder(paypalSetup);

                    var statusCode = response.StatusCode;
                    Order result = response.Result<Order>();
                    Console.WriteLine("Status: {0}", result.Status);
                    Console.WriteLine("Order Id: {0}", result.Id);
                    Console.WriteLine("Intent: {0}", result.CheckoutPaymentIntent);
                    Console.WriteLine("Links:");
                    foreach( PayPalCheckoutSdk.Orders.LinkDescription link in result.Links)
                    {
                        Console.WriteLine("\t{0}: {1}\tCall Type: (2)", link.Rel, link.Href, link.Method);
                        if (link.Rel.Trim().ToLower() == "approve")
                        {
                            paypalSetup.ApproveUrl = link.Href;
                        }
                    }

                    if (!string.IsNullOrEmpty(paypalSetup.ApproveUrl))
                        return Redirect(paypalSetup.ApproveUrl);
                }
                catch(Exception ex)
                {
                    paymentResultList.Add("There was an error in processing your payment. Details: " + ex.Message);
                    
                }
            }
            else
            {
                //Order Execution - Where the transaction is being carried out
                HttpResponse response = await MyPaypalPayment.CaptureOrder(paypalSetup);
                try
                {
                    var statusCode = response.StatusCode;
                    Order result = response.Result<Order>();
                    Console.WriteLine("Status: {0}", result.Status);
                    Console.WriteLine("Capture Id: {0}", result.Id);

                    //Update View so user can know status
                    if (result.Status.Trim().ToUpper() == "COMPLETED")
                    {
                        paymentResultList.Add("Payment Successful. Thank you.");
                    }
                    paymentResultList.Add("Payment State: " + result.Status);
                    paymentResultList.Add("Payment Id: " + result.Id);

                    if (result.PurchaseUnits != null && result.PurchaseUnits.Count > 0 && 
                        result.PurchaseUnits[0].Payments != null && result.PurchaseUnits[0].Payments.Captures != null &&
                        result.PurchaseUnits[0].Payments.Captures.Count > 0)
                    {
                        paymentResultList.Add("Transaction ID: " + result.PurchaseUnits[0].Payments.Captures[0].Id);
                    }
                }
                catch (Exception ex)
                {
                    paymentResultList.Add("There was an error in processing your payment");
                    paymentResultList.Add("Details: " + ex.Message);
                }
            }
            return View("Index", paymentResultList); 
        }

        public class MyPaypalPayment
        {
            public static PayPalHttpClient Client(MyPaypalSetup paypalEnvironment)
            {
                PayPalEnvironment environment = null;

                if (paypalEnvironment.Environment == "live")
                {
                    environment = new LiveEnvironment(paypalEnvironment.ClientId, paypalEnvironment.Secret);
                }
                else
                {
                    environment = new SandboxEnvironment(paypalEnvironment.ClientId, paypalEnvironment.Secret);
                }

                PayPalHttpClient client = new PayPalHttpClient(environment);
                return client;
            }

            public async static Task<HttpResponse> CreateOrder(MyPaypalSetup paypalSetup)
            {
                HttpResponse response = null;

                try
                {
                    //Order Creation
                    var order = new OrderRequest()
                    {
                        CheckoutPaymentIntent = "CAPTURE",
                        PurchaseUnits = new List<PurchaseUnitRequest>()
                        {
                            new PurchaseUnitRequest()
                            {
                                Items = new List<Item>()
                                {
                                    new Item()
                                    {
                                        Quantity = "1",
                                        Name = "Premium Membership",
                                        Description = "Upgrade to a StockView Premium Membership NOW!",
                                        Sku = "sku",
                                        Tax = new PayPalCheckoutSdk.Orders.Money(){ CurrencyCode = "USD", Value = "0.09"},
                                        UnitAmount = new PayPalCheckoutSdk.Orders.Money(){CurrencyCode = "USD", Value = "50.00"}
                                    }
                                },

                                AmountWithBreakdown = new AmountWithBreakdown()
                                {
                                    CurrencyCode = "USD",
                                    Value = "55.50",

                                    AmountBreakdown = new AmountBreakdown()
                                    {
                                        TaxTotal = new PayPalCheckoutSdk.Orders.Money()
                                        {
                                            CurrencyCode = "USD",
                                            Value = "4.50"
                                        },
                                        Shipping = new PayPalCheckoutSdk.Orders.Money()
                                        {
                                            CurrencyCode = "USD",
                                            Value = "1.00"
                                        },
                                        ItemTotal = new PayPalCheckoutSdk.Orders.Money
                                        {
                                            CurrencyCode = "USD",
                                            Value = "50.00"
                                        }
                                    }
                                }
                            }

                        },
                        ApplicationContext = new ApplicationContext()
                        {
                            ReturnUrl = paypalSetup.RedirectUrl,
                            CancelUrl = paypalSetup.RedirectUrl + "&Cancel=true"
                        }
                    };

                    //Imperative
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                    //API Call with client and get response
                    var request = new OrdersCreateRequest();
                    request.Prefer("return=representation");
                    request.RequestBody(order);
                    PayPalHttpClient payPalHttpClient = Client(paypalSetup);
                    response = await payPalHttpClient.Execute(request);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: {0}", e.Message);
                }
                return response;
            }

            public async static Task<HttpResponse> CaptureOrder(MyPaypalSetup paypalSetup)
            {
                //Building a request object and setting params
                var request = new OrdersCaptureRequest(paypalSetup.PayerApprovedOrderId);
                request.RequestBody(new OrderActionRequest());
                PayPalHttpClient payPalHttpClient = Client(paypalSetup);
                HttpResponse response = await payPalHttpClient.Execute(request);
                return response;
            }

            public class MyPaypalSetup
            {
                public String Environment { get; set; }

                public String ClientId { get; set; }

                public String Secret { get; set; }

                public String RedirectUrl { get; set; }

                public String ApproveUrl { get; set; }

                public String PayerApprovedOrderId { get; set; }
            }

                
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
        /*public async Task<IActionResult> Edit(int? id)
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
        }*/

    /*    public IActionResult Edit()
        {
            return View();
        }*/

        // POST: GenericUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
       /* [HttpPost]
        [ValidateAntiForgeryToken]*/
        /* public async Task<IActionResult> Edit(string id, [Bind("GenericUserId,Email,PasswordHash,FirstName,LastName,GenericUserName,GenericUserRole")] GenericUser genericUser)
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
         }*/

        // GET: GenericUsers/Delete/5
        /* public async Task<IActionResult> Delete(string id)
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
         }*/

        // POST: GenericUsers/Delete/5
        /*    [HttpPost, ActionName("Delete")]
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
            }*/

    }
}
