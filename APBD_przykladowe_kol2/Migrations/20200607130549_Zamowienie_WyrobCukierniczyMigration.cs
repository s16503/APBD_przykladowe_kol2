using Microsoft.EntityFrameworkCore.Migrations;

namespace APBD_przykladowe_kol2.Migrations
{
    public partial class Zamowienie_WyrobCukierniczyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Zamowienia_WyrobyCukiernicze",
                columns: table => new
                {
                    IdWyrobuCukierniczego = table.Column<int>(nullable: false),
                    IdZamowienia = table.Column<int>(nullable: false),
                    Ilosc = table.Column<int>(nullable: false),
                    Uwagi = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zamowienia_WyrobyCukiernicze", x => new { x.IdZamowienia, x.IdWyrobuCukierniczego });
                    table.ForeignKey(
                        name: "FK_Zamowienia_WyrobyCukiernicze_WyrobyCukiernicze_IdWyrobuCukierniczego",
                        column: x => x.IdWyrobuCukierniczego,
                        principalTable: "WyrobyCukiernicze",
                        principalColumn: "IdWyrobuCukierniczego",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zamowienia_WyrobyCukiernicze_Zamowienia_IdZamowienia",
                        column: x => x.IdZamowienia,
                        principalTable: "Zamowienia",
                        principalColumn: "IdZamowienia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienia_WyrobyCukiernicze_IdWyrobuCukierniczego",
                table: "Zamowienia_WyrobyCukiernicze",
                column: "IdWyrobuCukierniczego");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Zamowienia_WyrobyCukiernicze");
        }
    }
}
