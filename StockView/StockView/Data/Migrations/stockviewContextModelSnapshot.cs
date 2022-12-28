﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StockView.Data;

namespace StockView.Migrations
{
    [DbContext(typeof(StockviewDataContext))]
    partial class stockviewContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.30")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StockView.Models.HistoricalData", b =>
                {
                    b.Property<DateTime>("DateOfClose")
                        .HasColumnName("DateOfClose")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnName("Price")
                        .HasColumnType("decimal(6, 2)");

                    b.Property<string>("Ticker")
                        .HasColumnName("Ticker")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("HistoricalDatas");
                });

            modelBuilder.Entity("StockView.Models.Stocks", b =>
                {
                    b.Property<string>("Ticker")
                        .HasColumnName("Ticker")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AverageVolume")
                        .HasColumnName("AverageVolume")
                        .HasColumnType("int");

                    b.Property<decimal>("DayClose")
                        .HasColumnName("DayClose")
                        .HasColumnType("decimal(6, 2)");

                    b.Property<decimal>("DayOpen")
                        .HasColumnName("DayOpen")
                        .HasColumnType("decimal(6, 2)");

                    b.Property<string>("Exchange")
                        .HasColumnName("Exchange")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<long>("MarketCap")
                        .HasColumnName("MarketCap")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Price")
                        .HasColumnName("Price")
                        .HasColumnType("decimal(6, 2)");

                    b.Property<int>("Volume")
                        .HasColumnName("Volume")
                        .HasColumnType("int");

                    b.Property<decimal>("YearlyHigh")
                        .HasColumnName("YearlyHigh")
                        .HasColumnType("decimal(6, 2)");

                    b.Property<decimal>("YearlyLow")
                        .HasColumnName("YearlyLow")
                        .HasColumnType("decimal(6, 2)");

                    b.HasKey("Ticker");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("StockView.Models.Watchlist", b =>
                {
                    b.Property<int>("WatchlistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("watchlist_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Exchange")
                        .HasColumnName("Exchange")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GenericUserId")
                        .HasColumnName("generic_user_id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnName("Price")
                        .HasColumnType("decimal(6, 2)");

                    b.Property<string>("Ticker")
                        .HasColumnName("Ticker")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WatchlistName")
                        .HasColumnName("watchlist_name")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("WatchlistId");

                    b.ToTable("Watchlists");
                });
#pragma warning restore 612, 618
        }
    }
}
