using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace StockView.Models
{
    //DELETE THIS MODEL, NO NEED FOR IT ANYMORE
    [Table("usage_data")]
    public partial class UsageData
    {
        [Key]
        [Column("usage_id")]
        public int UsageId { get; set; }
        [Column("stock_buyers", TypeName = "decimal(10, 2)")]
        public decimal StockBuyers { get; set; }
        [Column("stock_sellers", TypeName = "decimal(10, 2)")]
        public decimal StockSellers { get; set; }
    }
}
