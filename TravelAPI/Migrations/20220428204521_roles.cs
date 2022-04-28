using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelAPI.Migrations
{
    public partial class roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllInclusive",
                table: "Wycieczki");

            migrationBuilder.DropColumn(
                name: "Rodzaj",
                table: "Pokoje");

            migrationBuilder.RenameColumn(
                name: "Nazwisko",
                table: "Klienci",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "Imie",
                table: "Klienci",
                newName: "passwordHash");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Klienci",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Klienci_RoleId",
                table: "Klienci",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Klienci_Role_RoleId",
                table: "Klienci",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Klienci_Role_RoleId",
                table: "Klienci");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropIndex(
                name: "IX_Klienci_RoleId",
                table: "Klienci");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Klienci");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "Klienci",
                newName: "Nazwisko");

            migrationBuilder.RenameColumn(
                name: "passwordHash",
                table: "Klienci",
                newName: "Imie");

            migrationBuilder.AddColumn<bool>(
                name: "AllInclusive",
                table: "Wycieczki",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Rodzaj",
                table: "Pokoje",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
