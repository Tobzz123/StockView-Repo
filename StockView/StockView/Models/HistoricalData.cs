using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace StockView.Models
{
    [Table("HistoricalData")]
    public class HistoricalData
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Ticker")]
        public string Ticker { get; set; }
        [Column("Price", TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }
        [Column("DateOfClose")]
        public DateTime DateOfClose { get; set; }
    }
}
