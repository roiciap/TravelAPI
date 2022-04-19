using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelAPI.Migrations
{
    public partial class three : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "Wycieczki");

            migrationBuilder.AddColumn<bool>(
                name: "AllInclusive",
                table: "Wycieczki",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Data",
                table: "Rezerwacje",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "koszt",
                table: "Pokoje",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllInclusive",
                table: "Wycieczki");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "Rezerwacje");

            migrationBuilder.DropColumn(
                name: "koszt",
                table: "Pokoje");

            migrationBuilder.AddColumn<string>(
                name: "Data",
                table: "Wycieczki",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
