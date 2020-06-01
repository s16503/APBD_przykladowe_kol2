using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APBD_przykladowe_kol2.Migrations
{
    public partial class InitailMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Klienci",
                columns: table => new
                {
                    IdKlient = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(nullable: false),
                    Nazwisko = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klienci", x => x.IdKlient);
                });

            migrationBuilder.CreateTable(
                name: "Pracownicy",
                columns: table => new
                {
                    IdPracownik = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(nullable: false),
                    Nazwisko = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pracownicy", x => x.IdPracownik);
                });

            migrationBuilder.CreateTable(
                name: "WyrobCukierniczy",
                columns: table => new
                {
                    IdWyrobuCukierniczego = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(nullable: true),
                    Cena = table.Column<float>(nullable: false),
                    Typ = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WyrobCukierniczy", x => x.IdWyrobuCukierniczego);
                });

            migrationBuilder.CreateTable(
                name: "Zamowienie",
                columns: table => new
                {
                    IdZamowienia = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataPrzyjecia = table.Column<DateTime>(nullable: false),
                    DataRealizacji = table.Column<DateTime>(nullable: false),
                    Uwagi = table.Column<string>(nullable: true),
                    IdKlienta = table.Column<int>(nullable: false),
                    IdPracownika = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zamowienie", x => x.IdZamowienia);
                    table.ForeignKey(
                        name: "FK_Zamowienie_Klienci_IdKlienta",
                        column: x => x.IdKlienta,
                        principalTable: "Klienci",
                        principalColumn: "IdKlient",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zamowienie_Pracownicy_IdPracownika",
                        column: x => x.IdPracownika,
                        principalTable: "Pracownicy",
                        principalColumn: "IdPracownik",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zamowienie_WyrobCukierniczy",
                columns: table => new
                {
                    IdWyrobuCukierniczego = table.Column<int>(nullable: false),
                    WyrobCukierniczyIdWyrobuCukierniczego = table.Column<int>(nullable: true),
                    IdZamowienia = table.Column<int>(nullable: false),
                    ZamowienieIdZamowienia = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Zamowienie_WyrobCukierniczy_WyrobCukierniczy_WyrobCukierniczyIdWyrobuCukierniczego",
                        column: x => x.WyrobCukierniczyIdWyrobuCukierniczego,
                        principalTable: "WyrobCukierniczy",
                        principalColumn: "IdWyrobuCukierniczego",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Zamowienie_WyrobCukierniczy_Zamowienie_ZamowienieIdZamowienia",
                        column: x => x.ZamowienieIdZamowienia,
                        principalTable: "Zamowienie",
                        principalColumn: "IdZamowienia",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienie_IdKlienta",
                table: "Zamowienie",
                column: "IdKlienta");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienie_IdPracownika",
                table: "Zamowienie",
                column: "IdPracownika");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienie_WyrobCukierniczy_WyrobCukierniczyIdWyrobuCukierniczego",
                table: "Zamowienie_WyrobCukierniczy",
                column: "WyrobCukierniczyIdWyrobuCukierniczego");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienie_WyrobCukierniczy_ZamowienieIdZamowienia",
                table: "Zamowienie_WyrobCukierniczy",
                column: "ZamowienieIdZamowienia");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Zamowienie_WyrobCukierniczy");

            migrationBuilder.DropTable(
                name: "WyrobCukierniczy");

            migrationBuilder.DropTable(
                name: "Zamowienie");

            migrationBuilder.DropTable(
                name: "Klienci");

            migrationBuilder.DropTable(
                name: "Pracownicy");
        }
    }
}
