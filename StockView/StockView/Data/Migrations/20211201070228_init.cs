using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StockView.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admins",
                columns: table => new
                {
                    admin_id = table.Column<int>(nullable: false),
                    email = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    first_name = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    last_name = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    admin_user_name = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    admin_user_role = table.Column<string>(unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__admins__43AA4141A968473A", x => x.admin_id);
                });
            
            migrationBuilder.CreateTable(
                name: "generic_user",
                columns: table => new
                {
                    generic_user_id = table.Column<string>(unicode: false, nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    email = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    password_hash = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    first_name = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    last_name = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    generic_user_name = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    generic_user_role = table.Column<string>(unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_generic_user", x => x.generic_user_id);
                });

            migrationBuilder.CreateTable(
                name: "manager",
                columns: table => new
                {
                    manager_id = table.Column<int>(nullable: false),
                    email = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    first_name = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    last_name = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    manager_user_name = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    manager_user_role = table.Column<string>(unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_manager", x => x.manager_id);
                });

            migrationBuilder.CreateTable(
                name: "stocks",
                columns: table => new
                {
                    Ticker = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(6, 2)", unicode: false, nullable: false),
                    Volume = table.Column<int>(unicode: false, nullable: false),
                    Market_Cap = table.Column<long>(unicode: false, nullable: false),
                    Exchange = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    Average_Volume = table.Column<int>(unicode: false, nullable: false),
                    DayOpen = table.Column<decimal>(type: "decimal(6, 2)", unicode: false, nullable: false),
                    DayClose = table.Column<decimal>(type: "decimal(6, 2)", unicode: false, nullable: false),
                    YearlyHigh = table.Column<decimal>(type: "decimal(6, 2)", unicode: false, nullable: false),
                    YearlyLow = table.Column<decimal>(type: "decimal(6, 2)", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__stocks__42AC12F161829BE6", x => x.Ticker);
                });

            migrationBuilder.CreateTable(
                name: "usage_data",
                columns: table => new
                {
                    usage_id = table.Column<int>(nullable: false),
                    stock_buyers = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    stock_sellers = table.Column<decimal>(type: "decimal(10, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__usage_da__B6B13A0230CBAD01", x => x.usage_id);
                });

            migrationBuilder.CreateTable(
                name: "Forums",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    forumId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Forums_generic_user_UserId",
                        column: x => x.UserId,
                        principalTable: "generic_user",
                        principalColumn: "generic_user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Forums_Forums_forumId",
                        column: x => x.forumId,
                        principalTable: "Forums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "watchlist",
                columns: table => new
                {
                    watchlist_id = table.Column<int>(nullable: false),
                    watchlist_name = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    generic_user_id = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_watchlist", x => x.watchlist_id);
                    table.ForeignKey(
                        name: "FK__watchlist__gener__267ABA7A",
                        column: x => x.generic_user_id,
                        principalTable: "generic_user",
                        principalColumn: "generic_user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    forumId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_generic_user_UserId",
                        column: x => x.UserId,
                        principalTable: "generic_user",
                        principalColumn: "generic_user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Posts_Forums_forumId",
                        column: x => x.forumId,
                        principalTable: "Forums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReplyPosts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    postId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReplyPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReplyPosts_generic_user_UserId",
                        column: x => x.UserId,
                        principalTable: "generic_user",
                        principalColumn: "generic_user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReplyPosts_Posts_postId",
                        column: x => x.postId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Forums_UserId",
                table: "Forums",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Forums_forumId",
                table: "Forums",
                column: "forumId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_forumId",
                table: "Posts",
                column: "forumId");

            migrationBuilder.CreateIndex(
                name: "IX_ReplyPosts_UserId",
                table: "ReplyPosts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReplyPosts_postId",
                table: "ReplyPosts",
                column: "postId");

            migrationBuilder.CreateIndex(
                name: "IX_watchlist_generic_user_id",
                table: "watchlist",
                column: "generic_user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admins");

            migrationBuilder.DropTable(
                name: "manager");

            migrationBuilder.DropTable(
                name: "ReplyPosts");

            migrationBuilder.DropTable(
                name: "stocks");

            migrationBuilder.DropTable(
                name: "usage_data");

            migrationBuilder.DropTable(
                name: "watchlist");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Forums");

            migrationBuilder.DropTable(
                name: "generic_user");
        }
    }
}
