using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StockView.Migrations
{
    public partial class AddedHistoricalData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_watchlist",
                table: "watchlist");

            migrationBuilder.RenameTable(
                name: "watchlist",
                newName: "Watchlist");

            migrationBuilder.RenameColumn(
                name: "WatchlistName",
                table: "Watchlist",
                newName: "watchlist_name");

            migrationBuilder.RenameColumn(
                name: "GenericUserId",
                table: "Watchlist",
                newName: "generic_user_id");

            migrationBuilder.RenameColumn(
                name: "WatchlistId",
                table: "Watchlist",
                newName: "watchlist_id");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Stocks",
                type: "decimal(6, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Exchange",
                table: "Stocks",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "watchlist_name",
                table: "Watchlist",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Exchange",
                table: "Watchlist",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Watchlist",
                type: "decimal(6, 2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Ticker",
                table: "Watchlist",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Watchlists",
                table: "Watchlist",
                column: "watchlist_id");

            migrationBuilder.CreateTable(
                name: "HistoricalDatas",
                columns: table => new
                {
                    Ticker = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(6, 2)", nullable: false),
                    DateOfClose = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoricalDatas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Watchlists",
                table: "Watchlists");

            migrationBuilder.DropColumn(
                name: "Exchange",
                table: "Watchlists");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Watchlists");

            migrationBuilder.DropColumn(
                name: "Ticker",
                table: "Watchlists");

            migrationBuilder.RenameTable(
                name: "Watchlists",
                newName: "watchlist");

            migrationBuilder.RenameColumn(
                name: "watchlist_name",
                table: "watchlist",
                newName: "WatchlistName");

            migrationBuilder.RenameColumn(
                name: "generic_user_id",
                table: "watchlist",
                newName: "GenericUserId");

            migrationBuilder.RenameColumn(
                name: "watchlist_id",
                table: "watchlist",
                newName: "WatchlistId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Stocks",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6, 2)");

            migrationBuilder.AlterColumn<string>(
                name: "Exchange",
                table: "Stocks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "WatchlistName",
                table: "watchlist",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_watchlist",
                table: "watchlist",
                column: "WatchlistId");
        }
    }
}
