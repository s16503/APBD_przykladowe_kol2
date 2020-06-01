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

        public ZamowieniaDbContext()
        {

        }

        public ZamowieniaDbContext(DbContextOptions options)
            :base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Klient>((builder) =>
            {
                builder.HasKey(e => e.IdKlient);
                builder.Property(e => e.IdKlient).ValueGeneratedOnAdd();
                builder.Property(e => e.Imie).IsRequired();
                builder.Property(e => e.Nazwisko).IsRequired();

                builder.HasMany(e => e.Zamowienia)
                        .WithOne(e => e.Klient)
                        .HasForeignKey(e => e.IdKlienta);

            });

            modelBuilder.Entity<Pracownik>((builder) =>
            {
                builder.HasKey(e => e.IdPracownik);
                builder.Property(e => e.IdPracownik).ValueGeneratedOnAdd();
                builder.Property(e => e.Imie).IsRequired();
                builder.Property(e => e.Nazwisko).IsRequired();

                builder.HasMany(e => e.Zamowienia)
                        .WithOne(e => e.Pracownik)
                        .HasForeignKey(e => e.IdPracownika);

            });
            

                 modelBuilder.Entity<WyrobCukierniczy>((builder) =>
                 {
                     builder.HasKey(e => e.IdWyrobuCukierniczego);
                     //builder.HasMany(e => e.Zamowienia_WyrobyCukiernicze)
                     //.WithOne(e => e.WyrobCukierniczy)
                     //.HasForeignKey(e=>e.IdWyrobuCukierniczego);
                     

                 });

           

            modelBuilder.Entity<Zamowienie>((builder) =>
            {
                builder.HasKey(e=>e.IdZamowienia);
            

                //builder.HasMany(e => e.Zamowienia_WyrobyCukiernicze)
                //    .WithOne(e => e.Zamowienie)
                //    .HasForeignKey(e => e.IdZamowienia);

            });

            modelBuilder.Entity<Zamowienie_WyrobCukierniczy>((builder) =>
            {
                builder.HasNoKey();

                builder.HasOne(e => e.Zamowienie);
                builder.HasOne(e => e.WyrobCukierniczy);

            });



        }

    }
}
