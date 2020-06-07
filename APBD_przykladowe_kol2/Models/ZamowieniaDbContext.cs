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


       


        public ZamowieniaDbContext(DbContext service)
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
        }


      



    }
}
