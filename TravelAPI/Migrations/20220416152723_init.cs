using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Klienci",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klienci", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lokalizacje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kraj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Miasto = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lokalizacje", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rezerwacje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KlientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezerwacje", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rezerwacje_Klienci_KlientId",
                        column: x => x.KlientId,
                        principalTable: "Klienci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hotele",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IloscGwiazdek = table.Column<int>(type: "int", nullable: false),
                    LokalizacjaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotele", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hotele_Lokalizacje_LokalizacjaId",
                        column: x => x.LokalizacjaId,
                        principalTable: "Lokalizacje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pokoje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rodzaj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HotelId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Wycieczki",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RezerwacjaId = table.Column<int>(type: "int", nullable: false),
                    PokojId = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wycieczki", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wycieczki_Pokoje_PokojId",
                        column: x => x.PokojId,
                        principalTable: "Pokoje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Wycieczki_Rezerwacje_RezerwacjaId",
                        column: x => x.RezerwacjaId,
                        principalTable: "Rezerwacje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hotele_LokalizacjaId",
                table: "Hotele",
                column: "LokalizacjaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pokoje_HotelId",
                table: "Pokoje",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezerwacje_KlientId",
                table: "Rezerwacje",
                column: "KlientId");

            migrationBuilder.CreateIndex(
                name: "IX_Wycieczki_PokojId",
                table: "Wycieczki",
                column: "PokojId");

            migrationBuilder.CreateIndex(
                name: "IX_Wycieczki_RezerwacjaId",
                table: "Wycieczki",
                column: "RezerwacjaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Wycieczki");

            migrationBuilder.DropTable(
                name: "Pokoje");

            migrationBuilder.DropTable(
                name: "Rezerwacje");

            migrationBuilder.DropTable(
                name: "Hotele");

            migrationBuilder.DropTable(
                name: "Klienci");

            migrationBuilder.DropTable(
                name: "Lokalizacje");
        }
    }
}
