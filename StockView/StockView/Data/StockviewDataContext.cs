using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using StockView.Models;


// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace StockView.Data
{
    public  class StockviewDataContext : DbContext
    {
        public DbSet<Stocks> Stocks { get; set; }

        public DbSet<Watchlist> Watchlists { get; set; }

        public DbSet<HistoricalData> HistoricalDatas { get; set; }
        public StockviewDataContext(DbContextOptions<StockviewDataContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }

       
      

      


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=stockview");
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<HistoricalData>().HasKey(e => e.Ticker);
            //modelBuilder.Entity<HistoricalData>().HasNoKey();
           /* modelBuilder.Entity<Stocks>(entity =>
            {
                entity.HasKey(e => e.Ticker)
                    .HasName("PK__stocks__42AC12F161829BE6");

                entity.Property(e => e.Ticker).IsUnicode(false);

                entity.Property(e => e.Price).IsUnicode(false);

                entity.Property(e => e.Volume).IsUnicode(false);

                entity.Property(e => e.MarketCap).IsUnicode(false);

                entity.Property(e => e.Exchange).IsUnicode(false);

                entity.Property(e => e.AverageVolume).IsUnicode(false);

                entity.Property(e => e.DayOpen).IsUnicode(false);

                entity.Property(e => e.DayClose).IsUnicode(false);

                entity.Property(e => e.YearlyHigh).IsUnicode(false);

                entity.Property(e => e.YearlyLow).IsUnicode(false);
            });

            modelBuilder.Entity<UsageData>(entity =>
            {
                entity.HasKey(e => e.UsageId)
                    .HasName("PK__usage_da__B6B13A0230CBAD01");

                entity.Property(e => e.UsageId).ValueGeneratedNever();

                entity.Property(e => e.StockBuyers);

                entity.Property(e => e.StockSellers);
            });

            modelBuilder.Entity<Watchlist>(entity =>
            {
                entity.HasKey(e => e.WatchlistId);

                entity.Property(e => e.WatchlistId).ValueGeneratedNever();

                entity.Property(e => e.GenericUserId).IsUnicode(false);

                entity.Property(e => e.WatchlistName).IsUnicode(false);

                entity.HasOne(d => d.GenericUser)
                    .WithMany(p => p.Watchlist)
                    .HasForeignKey(d => d.GenericUserId)
                    .HasConstraintName("FK__watchlist__gener__267ABA7A");
            });

            base.OnModelCreating(modelBuilder);*/
        }


    }
}
