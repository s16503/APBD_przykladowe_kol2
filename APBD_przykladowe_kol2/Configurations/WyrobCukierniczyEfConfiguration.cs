using APBD_przykladowe_kol2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_przykladowe_kol2.Configurations
{
    public class WyrobCukierniczyEfConfiguration : IEntityTypeConfiguration<WyrobCukierniczy>
    {
        public void Configure(EntityTypeBuilder<WyrobCukierniczy> builder)
        {


            builder.HasKey(e => e.IdWyrobuCukierniczego);
            builder.Property(e => e.IdWyrobuCukierniczego).ValueGeneratedOnAdd();
            builder.Property(e => e.Nazwa).IsRequired().HasMaxLength(200);
            builder.Property(e => e.CenaZaSzt).IsRequired();
            builder.Property(e => e.Typ).IsRequired().HasMaxLength(40);


            builder.HasMany(e => e.Zamowienia_WyrobyCukiernicze)
                 .WithOne(e => e.WyrobCukierniczy)
                 .HasForeignKey(e => e.IdWyrobuCukierniczego);

            var list = new List<WyrobCukierniczy>();
            int id = 1;
            list.Add(new WyrobCukierniczy { IdWyrobuCukierniczego = id, Nazwa = "Makowiec", CenaZaSzt = 15, Typ= "Ciasto" });
            list.Add(new WyrobCukierniczy { IdWyrobuCukierniczego = id+1, Nazwa = "Szarlotka", CenaZaSzt = 20, Typ = "Ciasto" });
            list.Add(new WyrobCukierniczy { IdWyrobuCukierniczego = id+2, Nazwa = "Beza", CenaZaSzt = 5, Typ = "Ciastko" });
            list.Add(new WyrobCukierniczy { IdWyrobuCukierniczego = id + 3, Nazwa = "Tort urodzinowy imienny", CenaZaSzt = 120, Typ = "Tort" });
            builder.HasData(list);
        }


    }
}
