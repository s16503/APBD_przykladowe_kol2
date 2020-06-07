using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APBD_przykladowe_kol2.Migrations
{
    public partial class SeedWyrobMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "WyrobyCukiernicze",
                columns: new[] { "IdWyrobuCukierniczego", "CenaZaSzt", "Nazwa", "Typ" },
                values: new object[] { 4, 120f, "Tort urodzinowy imienny", "Tort" });

            migrationBuilder.UpdateData(
                table: "Zamowienia",
                keyColumn: "IdZamowienia",
                keyValue: 1,
                column: "DataPrzyjecia",
                value: new DateTime(2020, 6, 7, 17, 43, 34, 423, DateTimeKind.Local).AddTicks(3254));

            migrationBuilder.UpdateData(
                table: "Zamowienia",
                keyColumn: "IdZamowienia",
                keyValue: 2,
                column: "DataPrzyjecia",
                value: new DateTime(2020, 6, 7, 17, 43, 34, 427, DateTimeKind.Local).AddTicks(5607));

            migrationBuilder.UpdateData(
                table: "Zamowienia",
                keyColumn: "IdZamowienia",
                keyValue: 3,
                column: "DataPrzyjecia",
                value: new DateTime(2020, 6, 7, 17, 43, 34, 427, DateTimeKind.Local).AddTicks(6368));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WyrobyCukiernicze",
                keyColumn: "IdWyrobuCukierniczego",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Zamowienia",
                keyColumn: "IdZamowienia",
                keyValue: 1,
                column: "DataPrzyjecia",
                value: new DateTime(2020, 6, 7, 15, 23, 3, 187, DateTimeKind.Local).AddTicks(3293));

            migrationBuilder.UpdateData(
                table: "Zamowienia",
                keyColumn: "IdZamowienia",
                keyValue: 2,
                column: "DataPrzyjecia",
                value: new DateTime(2020, 6, 7, 15, 23, 3, 194, DateTimeKind.Local).AddTicks(3450));

            migrationBuilder.UpdateData(
                table: "Zamowienia",
                keyColumn: "IdZamowienia",
                keyValue: 3,
                column: "DataPrzyjecia",
                value: new DateTime(2020, 6, 7, 15, 23, 3, 194, DateTimeKind.Local).AddTicks(4106));
        }
    }
}
