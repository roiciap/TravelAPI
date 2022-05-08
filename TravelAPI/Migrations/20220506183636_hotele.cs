using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelAPI.Migrations
{
    public partial class hotele : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wycieczki_Pokoje_PokojId",
                table: "Wycieczki");

            migrationBuilder.DropTable(
                name: "Pokoje");

            migrationBuilder.RenameColumn(
                name: "PokojId",
                table: "Wycieczki",
                newName: "HotelId");

            migrationBuilder.RenameIndex(
                name: "IX_Wycieczki_PokojId",
                table: "Wycieczki",
                newName: "IX_Wycieczki_HotelId");

            migrationBuilder.AddColumn<int>(
                name: "iloscPokoi",
                table: "Hotele",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "koszt",
                table: "Hotele",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Wycieczki_Hotele_HotelId",
                table: "Wycieczki",
                column: "HotelId",
                principalTable: "Hotele",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wycieczki_Hotele_HotelId",
                table: "Wycieczki");

            migrationBuilder.DropColumn(
                name: "iloscPokoi",
                table: "Hotele");

            migrationBuilder.DropColumn(
                name: "koszt",
                table: "Hotele");

            migrationBuilder.RenameColumn(
                name: "HotelId",
                table: "Wycieczki",
                newName: "PokojId");

            migrationBuilder.RenameIndex(
                name: "IX_Wycieczki_HotelId",
                table: "Wycieczki",
                newName: "IX_Wycieczki_PokojId");

            migrationBuilder.CreateTable(
                name: "Pokoje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    koszt = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokoje", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pokoje_Hotele_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotele",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pokoje_HotelId",
                table: "Pokoje",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wycieczki_Pokoje_PokojId",
                table: "Wycieczki",
                column: "PokojId",
                principalTable: "Pokoje",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
