using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace StockView.Models
{
    public class StockExchangeViewModel
    {
        public List<Stocks> Stocks {get;set;}
        public SelectList Exchanges { get; set;}

        public GenericUser GUser { get; set; }

        public string StockExchange { get; set; }
        public string SearchString { get; set; }
    }
}
