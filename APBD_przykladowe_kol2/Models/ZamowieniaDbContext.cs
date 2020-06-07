using APBD_przykladowe_kol2.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_przykladowe_kol2.Models
{
    public class ZamowieniaDbContext : DbContext
    {
        public DbSet<Klient> Klienci { get; set; }
        public DbSet<Pracownik> Pracownicy { get; set; }
        public DbSet<Zamowienie> Zamowienia { get; set; }
        public DbSet<WyrobCukierniczy> WyrobyCukiernicze { get; set; }
        public DbSet<Zamowienie_WyrobCukierniczy> Zamowienia_WyrobyCukiernicze { get; set; }





        public ZamowieniaDbContext()
        {

        }

        public ZamowieniaDbContext(DbContextOptions options)
            : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new KlientEfConfiguration());
            modelBuilder.ApplyConfiguration(new PracownikEfConfiguration());
            modelBuilder.ApplyConfiguration(new ZamowienieEfConfiguration());
            modelBuilder.ApplyConfiguration(new WyrobCukierniczyEfConfiguration());
            modelBuilder.ApplyConfiguration(new Zamowienie_WyrobCukierniczyEfConfiguration());




            //modelbuilder.entity<pracownik>((builder) =>
            //{
            //    builder.haskey(e => e.idpracownik);
            //    builder.property(e => e.idpracownik).valuegeneratedonadd();
            //    builder.property(e => e.imie).isrequired();
            //    builder.property(e => e.nazwisko).isrequired();

            //    builder.hasmany(e => e.zamowienia)
            //            .withone(e => e.pracownik)
            //            .hasforeignkey(e => e.idpracownika);

            //});


            //modelbuilder.entity<wyrobcukierniczy>((builder) =>
            //{
            //    builder.haskey(e => e.idwyrobucukierniczego);
            //    builder.property(e => e.idwyrobucukierniczego).valuegeneratedonadd();
            //    builder.property(e => e.nazwa).isrequired();
            //    builder.property(e => e.cenazaszt).isrequired();
            //    builder.property(e => e.typ).isrequired();


            //    builder.hasmany(e => e.zamowienia_wyrobycukiernicze)
            //    .withone(e => e.wyrobcukierniczy)
            //    .hasforeignkey(e => e.idwyrobucukierniczego);


            //});



            //modelbuilder.entity<zamowienie>((builder) =>
            //{
            //    builder.haskey(e => e.idzamowienia);
            //    builder.property(e => e.idzamowienia).valuegeneratedonadd();
            //    builder.property(e => e.dataprzyjecia).isrequired();

            //    builder.hasmany(e => e.zamowienia_wyrobycukiernicze)
            //       .withone(e => e.zamowienie)
            //       .hasforeignkey(e => e.idzamowienia);

            //});

            //modelbuilder.entity<zamowienie_wyrobcukierniczy>((builder) =>
            //{
            //    builder.haskey(e => e.idwyrobucukierniczego);
            //    builder.haskey(e => e.idzamowienia);

            //    builder.hasnokey();

            //    builder.property(e => e.ilosc).isrequired();

            //    builder.hasone(e => e.zamowienie);
            //    builder.hasone(e => e.wyrobcukierniczy);

            //});



        }
    }
}
