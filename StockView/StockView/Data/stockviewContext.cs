using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using StockView.Models;
using StockView.Models.Forum;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace StockView.Data
{
    public  class stockviewContext : IdentityDbContext<GenericUser>
    {
        public stockviewContext()
        {
        }

        public stockviewContext(DbContextOptions<stockviewContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admins> Admins { get; set; }
        public virtual DbSet<GenericUser> GenericUser { get; set; }
        public virtual DbSet<Manager> Manager { get; set; }
        public virtual DbSet<Stocks> Stocks { get; set; }
        public virtual DbSet<UsageData> UsageData { get; set; }
        public virtual DbSet<Watchlist> Watchlist { get; set; }

        public virtual DbSet<Forum> Forums { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<ReplyPost> ReplyPosts { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=stockview");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admins>(entity =>
            {
                entity.HasKey(e => e.AdminId)
                    .HasName("PK__admins__43AA4141A968473A");

                entity.Property(e => e.AdminId).ValueGeneratedNever();

                entity.Property(e => e.AdminUserName).IsUnicode(false);

                entity.Property(e => e.AdminUserRole).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);
            });

            modelBuilder.Entity<GenericUser>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

               /* entity.Property(e => e.GenericUserName).IsUnicode(false);

                entity.Property(e => e.GenericUserRole).IsUnicode(false);*/

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.PasswordHash).IsUnicode(false);
            });

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.HasKey(e => e.ManagerId);

                entity.Property(e => e.ManagerId).ValueGeneratedNever();

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.ManagerUserName).IsUnicode(false);

                entity.Property(e => e.ManagerUserRole).IsUnicode(false);
            });

            modelBuilder.Entity<Stocks>(entity =>
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

                entity.Property(e => e.DaytClose).IsUnicode(false);

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

            base.OnModelCreating(modelBuilder);
        }

       
    }
}
