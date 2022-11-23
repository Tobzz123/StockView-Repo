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
    public class StocksController : Controller
    {
        private readonly StockviewDataContext _context;
        private readonly ApplicationDbContext _appDbContext;
        List<Stocks> stocks = new List<Stocks>();

        public StocksController(StockviewDataContext context)
        {
            _context = context;
        }

        // GET: Stocks
        public async Task<IActionResult> Index(string stockExchange, string stockTicker)
        {
            //Using LINQ to get List of all Exchanges
            IQueryable<string> exchangeQuery = from st in _context.Stocks
                                               orderby st.Exchange
                                               select st.Exchange;

            var stocks = from s in _context.Stocks
                         select s;

            if (!string.IsNullOrEmpty(stockTicker))
            {
                stocks = stocks.Where(t => t.Ticker == stockTicker); 
            }

            if (!string.IsNullOrEmpty(stockExchange))
            {
                stocks = stocks.Where(x => x.Exchange == stockExchange);
            }

            var stockExchangeVM = new StockExchangeViewModel
            {
                Exchanges = new SelectList(await exchangeQuery.Distinct().ToListAsync()),
                Stocks = await stocks.ToListAsync()
            };

            return View(stockExchangeVM);
        }

       
        public async Task<IActionResult> Watchlist(string stockTicker, string userId)
        {
            
            var stock = from s in _context.Stocks
                        where s.Ticker == stockTicker
                        select s;
            List<Stocks> tempList = await stock.ToListAsync();

            //ViewBag.UserId;
            //Insert into watchlist using stock attributes: UserId, Ticker, Price, Exchange
            


            foreach (var item in tempList)
            {
                stocks.Add(item);
                _appDbContext.Database.ExecuteSqlRaw("INSERT INTO Watchlist (generic_user_id, Ticker, Price, Exchange) VALUES(" + userId + ", " + item.Ticker + ", " + item.Price + ", " + item.Exchange);
            }
           
            ViewBag.stocks = stocks;
            return View();
        }

        public IActionResult Chart (string stockTicker)
        {
            List<StockLineChart> stockList = new List<StockLineChart>();
            var result = (from s in _context.HistoricalDatas
                          where s.Ticker == stockTicker
                          select new { s.Price, s.DateOfClose });

            stockList = result.AsEnumerable()
                              .Select(sl => new StockLineChart
                              {
                                  Price = sl.Price,
                                  DateOfClose = sl.DateOfClose
                              }).ToList();
            return View(Json(new { JSONList = stockList }));
        }

        public JsonResult GetLineChartJSON(string stockTicker)
        {
           List<StockLineChart> stockList = new List<StockLineChart>();
           var result = (from s in _context.HistoricalDatas
                          where s.Ticker == stockTicker
                          select new { s.Price, s.DateOfClose });
             
           stockList = result.AsEnumerable()
                             .Select(sl => new StockLineChart
                             {
                                               Price = sl.Price,
                                               DateOfClose = sl.DateOfClose
                             }).ToList();
            return Json(new { JSONList = stockList });
        }

            // GET: Stocks/Details/5
            public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stocks = await _context.Stocks
                .FirstOrDefaultAsync(m => m.Ticker == id);
            if (stocks == null)
            {
                return NotFound();
            }

            return View(stocks);
        }

        // GET: Stocks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Stocks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Ticker,Price,Volume,MarketCap,Exchange,AverageVolume,DayOpen,DayClose,YearlyHigh,YearlyLow")] Stocks stocks)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stocks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stocks);
        }

        // GET: Stocks/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stocks = await _context.Stocks.FindAsync(id);
            if (stocks == null)
            {
                return NotFound();
            }
            return View(stocks);
        }

        // POST: Stocks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Ticker,Price,Volume,MarketCap,Exchange,AverageVolume,DayOpen,DayClose,YearlyHigh,YearlyLow")] Stocks stocks)
        {
            if (id != stocks.Ticker)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stocks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StocksExists(stocks.Ticker))
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
            return View(stocks);
        }

        // GET: Stocks/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stocks = await _context.Stocks
                .FirstOrDefaultAsync(m => m.Ticker == id);
            if (stocks == null)
            {
                return NotFound();
            }

            return View(/*stocks*/);
        }

        // POST: Stocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var stocks = await _context.Stocks.FindAsync(id);
            _context.Stocks.Remove(stocks);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StocksExists(string id)
        {
            return _context.Stocks.Any(e => e.Ticker == id); 
        }

       
    }
}
