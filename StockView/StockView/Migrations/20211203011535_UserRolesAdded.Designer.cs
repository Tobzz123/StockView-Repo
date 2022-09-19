﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StockView.Data;

namespace StockView.Migrations
{
    [DbContext(typeof(stockviewContext))]
    [Migration("20211203011535_UserRolesAdded")]
    partial class UserRolesAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(900)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(900)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(900)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(900)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("StockView.Models.Admins", b =>
                {
                    b.Property<int>("AdminId")
                        .HasColumnName("admin_id")
                        .HasColumnType("int");

                    b.Property<string>("AdminUserName")
                        .HasColumnName("admin_user_name")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("AdminUserRole")
                        .HasColumnName("admin_user_role")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("FirstName")
                        .HasColumnName("first_name")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("LastName")
                        .HasColumnName("last_name")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.HasKey("AdminId")
                        .HasName("PK__admins__43AA4141A968473A");

                    b.ToTable("admins");
                });

            modelBuilder.Entity("StockView.Models.Forum.Forum", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(900)");

                    b.Property<int?>("forumId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("forumId");

                    b.ToTable("Forums");
                });

            modelBuilder.Entity("StockView.Models.Forum.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(900)");

                    b.Property<int?>("forumId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("forumId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("StockView.Models.Forum.ReplyPost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(900)");

                    b.Property<int?>("postId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("postId");

                    b.ToTable("ReplyPosts");
                });

            modelBuilder.Entity("StockView.Models.GenericUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnName("generic_user_id")
                        .HasColumnType("varchar(900)")
                        .IsUnicode(false);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnName("email")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256)
                        .IsUnicode(false);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnName("first_name")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("GenericUserName")
                        .HasColumnName("generic_user_name")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("GenericUserRole")
                        .HasColumnName("generic_user_role")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("LastName")
                        .HasColumnName("last_name")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnName("password_hash")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("StockView.Models.Manager", b =>
                {
                    b.Property<int>("ManagerId")
                        .HasColumnName("manager_id")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnName("email")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("FirstName")
                        .HasColumnName("first_name")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("LastName")
                        .HasColumnName("last_name")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("ManagerUserName")
                        .HasColumnName("manager_user_name")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("ManagerUserRole")
                        .HasColumnName("manager_user_role")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.HasKey("ManagerId");

                    b.ToTable("manager");
                });

            modelBuilder.Entity("StockView.Models.Stocks", b =>
                {
                    b.Property<string>("Ticker")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<int>("AverageVolume")
                        .HasColumnName("Average_Volume")
                        .HasColumnType("int")
                        .IsUnicode(false);

                    b.Property<decimal>("DayOpen")
                        .HasColumnType("decimal(6, 2)")
                        .IsUnicode(false);

                    b.Property<decimal>("DaytClose")
                        .HasColumnType("decimal(6, 2)")
                        .IsUnicode(false);

                    b.Property<string>("Exchange")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<long>("MarketCap")
                        .HasColumnName("Market_Cap")
                        .HasColumnType("bigint")
                        .IsUnicode(false);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(6, 2)")
                        .IsUnicode(false);

                    b.Property<int>("Volume")
                        .HasColumnType("int")
                        .IsUnicode(false);

                    b.Property<decimal>("YearlyHigh")
                        .HasColumnType("decimal(6, 2)")
                        .IsUnicode(false);

                    b.Property<decimal>("YearlyLow")
                        .HasColumnType("decimal(6, 2)")
                        .IsUnicode(false);

                    b.HasKey("Ticker")
                        .HasName("PK__stocks__42AC12F161829BE6");

                    b.ToTable("stocks");
                });

            modelBuilder.Entity("StockView.Models.UsageData", b =>
                {
                    b.Property<int>("UsageId")
                        .HasColumnName("usage_id")
                        .HasColumnType("int");

                    b.Property<decimal>("StockBuyers")
                        .HasColumnName("stock_buyers")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<decimal>("StockSellers")
                        .HasColumnName("stock_sellers")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("UsageId")
                        .HasName("PK__usage_da__B6B13A0230CBAD01");

                    b.ToTable("usage_data");
                });

            modelBuilder.Entity("StockView.Models.Watchlist", b =>
                {
                    b.Property<int>("WatchlistId")
                        .HasColumnName("watchlist_id")
                        .HasColumnType("int");

                    b.Property<string>("GenericUserId")
                        .HasColumnName("generic_user_id")
                        .HasColumnType("varchar(900)")
                        .IsUnicode(false);

                    b.Property<string>("WatchlistName")
                        .HasColumnName("watchlist_name")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.HasKey("WatchlistId");

                    b.HasIndex("GenericUserId");

                    b.ToTable("watchlist");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("StockView.Models.GenericUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("StockView.Models.GenericUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StockView.Models.GenericUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("StockView.Models.GenericUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StockView.Models.Forum.Forum", b =>
                {
                    b.HasOne("StockView.Models.GenericUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.HasOne("StockView.Models.Forum.Forum", "forum")
                        .WithMany()
                        .HasForeignKey("forumId");
                });

            modelBuilder.Entity("StockView.Models.Forum.Post", b =>
                {
                    b.HasOne("StockView.Models.GenericUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.HasOne("StockView.Models.Forum.Forum", "forum")
                        .WithMany("Posts")
                        .HasForeignKey("forumId");
                });

            modelBuilder.Entity("StockView.Models.Forum.ReplyPost", b =>
                {
                    b.HasOne("StockView.Models.GenericUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.HasOne("StockView.Models.Forum.Post", "post")
                        .WithMany("Replies")
                        .HasForeignKey("postId");
                });

            modelBuilder.Entity("StockView.Models.Watchlist", b =>
                {
                    b.HasOne("StockView.Models.GenericUser", "GenericUser")
                        .WithMany("Watchlist")
                        .HasForeignKey("GenericUserId")
                        .HasConstraintName("FK__watchlist__gener__267ABA7A");
                });
#pragma warning restore 612, 618

        }
    }
}
