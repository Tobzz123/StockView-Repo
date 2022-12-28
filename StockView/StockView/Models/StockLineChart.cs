using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper.Configuration.Attributes;

namespace StockView.Models
{
    public class StockLineChart
    {
        public string Ticker { get; set; }
        public decimal Price { get; set; }
        [Format("yyyy-MM-dd")]
        public DateTime DateOfClose { get; set; }

        public static StockLineChart FromCsv(string csvLine, string fileName)
        {
            string[] values = csvLine.Split(',');
            StockLineChart dailyValues = new StockLineChart();
            dailyValues.Ticker = fileName.Substring(0, fileName.IndexOf('.'));
            dailyValues.Price = Convert.ToDecimal(values[4]);
            dailyValues.DateOfClose = Convert.ToDateTime(values[0]).Date;
            return dailyValues;
        }
    }
}
