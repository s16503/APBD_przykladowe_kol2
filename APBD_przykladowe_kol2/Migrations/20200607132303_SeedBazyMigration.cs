using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APBD_przykladowe_kol2.Migrations
{
    public partial class SeedBazyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Klienci",
                columns: new[] { "IdKlient", "Imie", "Nazwisko" },
                values: new object[,]
                {
                    { 1, "Jan", "Kowalski" },
                    { 2, "Andrzej", "Nowak" },
                    { 3, "Łucja", "Kawka" }
                });

            migrationBuilder.InsertData(
                table: "Pracownicy",
                columns: new[] { "IdPracownik", "Imie", "Nazwisko" },
                values: new object[,]
                {
                    { 1, "Alex", "Nixon" },
                    { 2, "Anna", "Jarawska" },
                    { 3, "Jan", "Kox" }
                });

            migrationBuilder.InsertData(
                table: "WyrobyCukiernicze",
                columns: new[] { "IdWyrobuCukierniczego", "CenaZaSzt", "Nazwa", "Typ" },
                values: new object[,]
                {
                    { 1, 15f, "Makowiec", "Ciasto" },
                    { 2, 20f, "Szarlotka", "Ciasto" },
                    { 3, 5f, "Beza", "Ciastko" }
                });

            migrationBuilder.InsertData(
                table: "Zamowienia",
                columns: new[] { "IdZamowienia", "DataPrzyjecia", "DataRealizacji", "IdKlienta", "IdPracownika", "Uwagi" },
                values: new object[] { 1, new DateTime(2020, 6, 7, 15, 23, 3, 187, DateTimeKind.Local).AddTicks(3293), new DateTime(2020, 6, 7, 0, 0, 0, 0, DateTimeKind.Local), 1, 1, null });

            migrationBuilder.InsertData(
                table: "Zamowienia",
                columns: new[] { "IdZamowienia", "DataPrzyjecia", "DataRealizacji", "IdKlienta", "IdPracownika", "Uwagi" },
                values: new object[] { 2, new DateTime(2020, 6, 7, 15, 23, 3, 194, DateTimeKind.Local).AddTicks(3450), new DateTime(2020, 6, 7, 0, 0, 0, 0, DateTimeKind.Local), 2, 2, "świeże ma być" });

            migrationBuilder.InsertData(
                table: "Zamowienia",
                columns: new[] { "IdZamowienia", "DataPrzyjecia", "DataRealizacji", "IdKlienta", "IdPracownika", "Uwagi" },
                values: new object[] { 3, new DateTime(2020, 6, 7, 15, 23, 3, 194, DateTimeKind.Local).AddTicks(4106), new DateTime(2020, 6, 7, 0, 0, 0, 0, DateTimeKind.Local), 3, 2, null });

            migrationBuilder.InsertData(
                table: "Zamowienia_WyrobyCukiernicze",
                columns: new[] { "IdZamowienia", "IdWyrobuCukierniczego", "Ilosc", "Uwagi" },
                values: new object[] { 1, 3, 1, null });

            migrationBuilder.InsertData(
                table: "Zamowienia_WyrobyCukiernicze",
                columns: new[] { "IdZamowienia", "IdWyrobuCukierniczego", "Ilosc", "Uwagi" },
                values: new object[] { 2, 2, 4, null });

            migrationBuilder.InsertData(
                table: "Zamowienia_WyrobyCukiernicze",
                columns: new[] { "IdZamowienia", "IdWyrobuCukierniczego", "Ilosc", "Uwagi" },
                values: new object[] { 3, 1, 2, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pracownicy",
                keyColumn: "IdPracownik",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Zamowienia_WyrobyCukiernicze",
                keyColumns: new[] { "IdZamowienia", "IdWyrobuCukierniczego" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "Zamowienia_WyrobyCukiernicze",
                keyColumns: new[] { "IdZamowienia", "IdWyrobuCukierniczego" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Zamowienia_WyrobyCukiernicze",
                keyColumns: new[] { "IdZamowienia", "IdWyrobuCukierniczego" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "WyrobyCukiernicze",
                keyColumn: "IdWyrobuCukierniczego",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WyrobyCukiernicze",
                keyColumn: "IdWyrobuCukierniczego",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WyrobyCukiernicze",
                keyColumn: "IdWyrobuCukierniczego",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Zamowienia",
                keyColumn: "IdZamowienia",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Zamowienia",
                keyColumn: "IdZamowienia",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Zamowienia",
                keyColumn: "IdZamowienia",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Klienci",
                keyColumn: "IdKlient",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Klienci",
                keyColumn: "IdKlient",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Klienci",
                keyColumn: "IdKlient",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pracownicy",
                keyColumn: "IdPracownik",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pracownicy",
                keyColumn: "IdPracownik",
                keyValue: 2);
        }
    }
}
