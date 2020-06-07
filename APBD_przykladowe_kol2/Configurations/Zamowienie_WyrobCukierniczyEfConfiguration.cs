using APBD_przykladowe_kol2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_przykladowe_kol2.Configurations
{
 
    public class Zamowienie_WyrobCukierniczyEfConfiguration : IEntityTypeConfiguration<Zamowienie_WyrobCukierniczy>
    {
        public void Configure(EntityTypeBuilder<Zamowienie_WyrobCukierniczy> builder)
        {
            
            builder.Property(e => e.Ilosc).IsRequired();
            builder.Property(e => e.Uwagi).HasMaxLength(300);
            builder.HasKey(e => new { e.IdZamowienia, e.IdWyrobuCukierniczego });



            var list = new List<Zamowienie_WyrobCukierniczy>();
            int id = 1;
            list.Add(new Zamowienie_WyrobCukierniczy { IdWyrobuCukierniczego = id, IdZamowienia = id+2, Ilosc=2 });
            list.Add(new Zamowienie_WyrobCukierniczy { IdWyrobuCukierniczego = id+1, IdZamowienia = id +1, Ilosc = 4 });
            list.Add(new Zamowienie_WyrobCukierniczy { IdWyrobuCukierniczego = id+2, IdZamowienia = id, Ilosc = 1 });

            builder.HasData(list);


        }

       
    }
}
