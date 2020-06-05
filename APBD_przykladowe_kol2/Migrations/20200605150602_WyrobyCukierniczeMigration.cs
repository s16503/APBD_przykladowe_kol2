using Microsoft.EntityFrameworkCore.Migrations;

namespace APBD_przykladowe_kol2.Migrations
{
    public partial class WyrobyCukierniczeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WyrobyCukiernicze",
                columns: table => new
                {
                    IdWyrobuCukierniczego = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(maxLength: 200, nullable: false),
                    CenaZaSzt = table.Column<float>(nullable: false),
                    Typ = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WyrobyCukiernicze", x => x.IdWyrobuCukierniczego);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WyrobyCukiernicze");
        }
    }
}
