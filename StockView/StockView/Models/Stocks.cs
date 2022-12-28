using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace StockView.Models
{
    
    public class Stocks
    {
        [Key]
        [Column("Ticker")]
        public string Ticker { get; set; }
        [Column("Price", TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }
        [Column("Volume")]
        public int Volume { get; set; }
        
        [Column("MarketCap")]
        [Display(Name = "Market Cap")]
        public long MarketCap { get; set; }
        [Column("Exchange")]
        [StringLength(255)]
        public string Exchange { get; set; }
        [Column("AverageVolume")]
        public int AverageVolume { get; set; }
        [Column("DayOpen", TypeName = "decimal(6, 2)")]
        public decimal DayOpen { get; set; }
        [Column("DayClose", TypeName = "decimal(6, 2)")]
        public decimal DayClose { get; set; }
        [Column("YearlyHigh", TypeName = "decimal(6, 2)")]
        public decimal YearlyHigh { get; set; }
        [Column("YearlyLow", TypeName = "decimal(6, 2)")]
        public decimal YearlyLow { get; set; }
    }
}
