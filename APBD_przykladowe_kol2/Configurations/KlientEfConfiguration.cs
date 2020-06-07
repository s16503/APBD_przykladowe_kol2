using APBD_przykladowe_kol2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_przykladowe_kol2.Configurations
{
    public class KlientEfConfiguration : IEntityTypeConfiguration<Klient>
    {
        public void Configure(EntityTypeBuilder<Klient> builder)
        {
            //base.OnModelCreating(builder);

            builder.HasKey(e => e.IdKlient);
            builder.Property(e => e.IdKlient).ValueGeneratedOnAdd();
            builder.Property(e => e.Imie).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Nazwisko).IsRequired().HasMaxLength(60);

            builder.HasMany(e => e.Zamowienia)
                    .WithOne(e => e.Klient)
                    .HasForeignKey(e => e.IdKlienta);

            var list = new List<Klient>();
            int id = 1;
            list.Add(new Klient {IdKlient=id, Imie = "Jan",Nazwisko = "Kowalski"});
            list.Add(new Klient { IdKlient = id+1, Imie = "Andrzej", Nazwisko = "Nowak" });
            list.Add(new Klient { IdKlient = id+2, Imie = "Łucja", Nazwisko = "Kawka" });

            builder.HasData(list);


        }


    }
}
