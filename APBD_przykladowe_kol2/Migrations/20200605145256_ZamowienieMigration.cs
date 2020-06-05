using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APBD_przykladowe_kol2.Migrations
{
    public partial class ZamowienieMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Zamowienia",
                columns: table => new
                {
                    IdZamowienia = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataPrzyjecia = table.Column<DateTime>(nullable: false),
                    DataRealizacji = table.Column<DateTime>(nullable: false),
                    Uwagi = table.Column<string>(maxLength: 300, nullable: true),
                    IdKlienta = table.Column<int>(nullable: false),
                    IdPracownika = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zamowienia", x => x.IdZamowienia);
                    table.ForeignKey(
                        name: "FK_Zamowienia_Klienci_IdKlienta",
                        column: x => x.IdKlienta,
                        principalTable: "Klienci",
                        principalColumn: "IdKlient",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zamowienia_Pracownicy_IdPracownika",
                        column: x => x.IdPracownika,
                        principalTable: "Pracownicy",
                        principalColumn: "IdPracownik",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienia_IdKlienta",
                table: "Zamowienia",
                column: "IdKlienta");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienia_IdPracownika",
                table: "Zamowienia",
                column: "IdPracownika");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Zamowienia");
        }
    }
}
