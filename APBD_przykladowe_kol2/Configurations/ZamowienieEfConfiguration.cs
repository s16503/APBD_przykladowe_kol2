using APBD_przykladowe_kol2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_przykladowe_kol2.Configurations
{
    public class ZamowienieEfConfiguration : IEntityTypeConfiguration<Zamowienie>
    {
        public void Configure(EntityTypeBuilder<Zamowienie> builder)
        {
            //base.OnModelCreating(builder);

            builder.HasKey(e => e.IdZamowienia);
            builder.Property(e => e.IdZamowienia).ValueGeneratedOnAdd();
            builder.Property(e => e.IdZamowienia).IsRequired();
            builder.Property(e => e.Uwagi).HasMaxLength(300);
            //builder.Property(e => e.IdKlienta).IsRequired();
            //builder.Property(e => e.IdPracownika).IsRequired();
            builder.Property(e => e.DataPrzyjecia).IsRequired();




            builder.HasMany(e => e.Zamowienia_WyrobyCukiernicze)
               .WithOne(e => e.Zamowienie)
               .HasForeignKey(e => e.IdZamowienia);


            var list = new List<Zamowienie>();
            int id = 1;
            list.Add(new Zamowienie { IdZamowienia= id, IdPracownika = 1, IdKlienta = 1, DataPrzyjecia =DateTime.Now, DataRealizacji=DateTime.Today });
            list.Add(new Zamowienie { IdZamowienia = id+1, IdPracownika = 2, IdKlienta = 2, DataPrzyjecia = DateTime.Now, DataRealizacji = DateTime.Today, Uwagi="świeże ma być" });
            list.Add(new Zamowienie { IdZamowienia = id+2, IdPracownika = 2, IdKlienta = 3, DataPrzyjecia = DateTime.Now, DataRealizacji = DateTime.Today });

            builder.HasData(list);


        }


    }
}
