using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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


        public AdminsController(ApplicationDbContext context, StockviewDataContext stockContext)
        {
            _context = context;
            _stockviewcontext = stockContext;
        }

        // GET: Admins
        //Home Page for Admin - All functionality should be displayed here
        public IActionResult Index()
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

        //This should just be a string instead of Guid
        public IActionResult UpdateUserWatchlist(string id)
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

        [HttpDelete]
        public IActionResult DeleteUserWatchlist(String email)
        {
            try
            {
                //Delete all records from Watchlist table where ID is generic Users ID
                //IF successful return viewbag
                 var userId = from u in _context.Users
                              where u.Email == email
                              select u.Id;
   
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

        public ActionResult UploadCsv()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadCsv(List<IFormFile> formFiles)
        {
            try
            {
               /* _stockviewcontext.Entry(_stockviewcontext.HistoricalDatas).State = EntityState.Detached;
                
                _stockviewcontext.Set<DbSet<HistoricalData>>().Update(_stockviewcontext.HistoricalDatas);
                _stockviewcontext.SaveChanges();*/

                //Save File before reading it from HistoricalFolder tab
                /* using (var reader = new StreamReader(fileName))
                 using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                 {
                     var records = csv.GetRecords<StockLineChart>();
                 }*/
                //Read in CSV file
                if (formFiles.Count != 0)
                {
                    foreach (var formFile in formFiles)
                    {
                        var supportedTypes = new[] { "csv" };

                        var fileExt = Path.GetExtension(formFile.FileName).Substring(1);
                        if (!supportedTypes.Contains(fileExt))
                        {
                            ViewBag.Message = "File Extension Is Invalid - Only Upload CSV File";
                        }
                        else
                        {
                            /*using (var data = new MemoryStream())
                            {*/
                                //formFile.CopyTo(data);
                                
                                using (StreamReader reader = new StreamReader(formFile.OpenReadStream())) //data
                                {
                                    reader.ReadLine();
                                    string line;
                                    StockLineChart stockLine;

                                    //If Ticker isn't already in the database, populate
                                    if (_stockviewcontext.HistoricalDatas.Where(a => a.Ticker == Path.GetFileName(formFile.FileName).Substring(0, formFile.FileName.IndexOf("."))) == null)                            {
                                        while (!reader.EndOfStream)
                                        {
                                            line = reader.ReadLine();
                                            stockLine = StockLineChart.FromCsv(line, Path.GetFileName(formFile.FileName));
                                            await _stockviewcontext.HistoricalDatas.AddAsync(new HistoricalData
                                            {
                                                Ticker = stockLine.Ticker,
                                                Price = stockLine.Price,
                                                DateOfClose = stockLine.DateOfClose.Date
                                            });

                                            _stockviewcontext.SaveChanges();
                                            
                                        }
                                    ViewBag.Message = "Successfully Uploaded File!";
                                }
                                    //If Ticker Data already exists, then delete old data first before populating
                                    else
                                    {
                                        List<HistoricalData> oldHistoricalData = new List<HistoricalData>();
                                            var result =    from h in _stockviewcontext.HistoricalDatas
                                                            .Where(h => h.Ticker == Path.GetFileName(formFile.FileName).Substring(0, formFile.FileName.IndexOf(".")))
                                                            select h;
                                        oldHistoricalData = await result.ToListAsync();

                                        foreach (var oldData in oldHistoricalData)
                                        {
                                            _stockviewcontext.HistoricalDatas.Remove(oldData);
                                        }
                                        _stockviewcontext.SaveChanges();

                                       /* if (_stockviewcontext.Database.ExecuteSqlRaw("DELETE FROM HistoricalData WHERE Ticker = '" + Path.GetFileName(formFile.FileName).Substring(0, formFile.FileName.IndexOf(".")) + "'") > 0)*/
                                            //if(_stockviewcontext.HistoricalDatas.Remove
                                            //_stockviewcontext.SaveChanges();
                                        
                                            while (!reader.EndOfStream)
                                            {
                                                line = reader.ReadLine();
                                                stockLine = StockLineChart.FromCsv(line, Path.GetFileName(formFile.FileName));
                                                await _stockviewcontext.HistoricalDatas.AddAsync(new HistoricalData
                                                {
                                                    Ticker = stockLine.Ticker,
                                                    Price = stockLine.Price,
                                                    DateOfClose = stockLine.DateOfClose.Date
                                                });

                                                _stockviewcontext.SaveChanges();
                                            }
                                    ViewBag.Message = "Successfully Uploaded File!";
                                }

                                /*}*/
                            }
                        }
                    }
                }
                else
                {
                    ViewBag.Message = "File was not uploaded correctly.";
                }
                /*List<StockLineChart> values = new List<StockLineChart>();
                    using (StreamReader reader = new StreamReader(file.OpenReadStream()))
                    {
                        reader.ReadLine();
                        string line;
                        while (!reader.EndOfStream)
                        {
                            line = reader.ReadLine();
                            values.Add(StockLineChart.FromCsv(line, Path.GetFileName(file.FileName)));
                        }
                    }

                        *//*file.OpenReadStream(System.IO.File.ReadAllLines(file.FileName)
                                             .Skip(1)
                                             .Select(v => StockLineChart.FromCsv(v, file.FileName))
                                             .ToList());*//*
                    //Insert StockLineChart list into sql Database. Check if records already exist!


                    if (_stockviewcontext.Database.ExecuteSqlRaw("SELECT Ticker FROM HistoricalData WHERE Ticker = " + file.FileName.Substring(0, file.FileName.IndexOf("."))) == 0)
                    {
                        foreach (StockLineChart sl in values)
                        {
                            _stockviewcontext.Database.ExecuteSqlRaw("INSERT INTO HistoricalData VALUES( '" + sl.Ticker + "', " + sl.Price + ", '" + sl.DateOfClose.ToString() + "'");

                        }
                    }
                    else
                    {
                        if (_stockviewcontext.Database.ExecuteSqlRaw("DELETE FROM HistoricalData WHERE Ticker = '" + file.FileName.Substring(0, file.FileName.IndexOf("."))) > 0)
                        {
                            foreach (StockLineChart sl in values)
                            {
                                _stockviewcontext.Database.ExecuteSqlRaw("INSERT INTO HistoricalData VALUES( '" + sl.Ticker + "', " + sl.Price + ", '" + sl.DateOfClose.ToString() + "'");
                            }
                        }

                    }*/





                //Strip all columns except for Price, Date
                //Use first part of file name up until the first period as Ticker field
                //Insert this data as records into Watchlist table
                return View();
            }
            catch (Exception e)
            {
                return View("Error",
           new ErrorViewModel
           {
               RequestId = e.ToString(),
               Description = "Error." + e.Message
           });
            }
        }

                [HttpGet]
                public IActionResult Create()
                {

                    return View();
                }

               

            
            }
}
