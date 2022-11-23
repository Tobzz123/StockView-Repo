using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace StockView.Models
{
    //[Table("watchlist")]
    public class Watchlist
    {
        [Key]
     //   [Column("watchlist_id")]
        public int WatchlistId { get; set; }
       // [Column("watchlist_name")]
        //[StringLength(255)]
        public string WatchlistName { get; set; }
        //[Column("generic_user_id")]
        public string GenericUserId { get; set; }

        public string Ticker { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public double Price { get; set; }

        public string Exchange { get; set; }

       /* [ForeignKey("GenericUserId")]
        public virtual GenericUser GenericUser { get; set; }*/
    }
}
