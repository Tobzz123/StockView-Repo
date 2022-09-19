using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace StockView.Models
{
    [Table("stocks")]
    public partial class Stocks
    {
        [Key]
        [StringLength(255)]
        public string Ticker { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }
        public int Volume { get; set; }
        [Column("Market_Cap")]
        public long MarketCap { get; set; }
        [StringLength(255)]
        public string Exchange { get; set; }
        [Column("Average_Volume")]
        public int AverageVolume { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal DayOpen { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal DaytClose { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal YearlyHigh { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal YearlyLow { get; set; }
    }
}
