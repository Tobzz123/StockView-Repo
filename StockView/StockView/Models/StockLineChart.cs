using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockView.Models
{
    public class StockLineChart
    {
        public string Ticker { get; set; }
        public decimal Price { get; set; }
        public string DateOfClose { get; set; }
    }
}
