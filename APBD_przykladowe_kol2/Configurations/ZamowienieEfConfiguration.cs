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




            //builder.HasMany(e => e.zamowienia_wyrobycukiernicze)
            //   .withone(e => e.zamowienie)
            //   .hasforeignkey(e => e.idzamowienia);
        }


    }
}
