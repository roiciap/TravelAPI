using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelAPI.Migrations
{
    public partial class hmm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "Rezerwacje");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEnd",
                table: "Wycieczki",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateStart",
                table: "Wycieczki",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ImgUri",
                table: "Hotele",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateEnd",
                table: "Wycieczki");

            migrationBuilder.DropColumn(
                name: "DateStart",
                table: "Wycieczki");

            migrationBuilder.DropColumn(
                name: "ImgUri",
                table: "Hotele");

            migrationBuilder.AddColumn<string>(
                name: "Data",
                table: "Rezerwacje",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
