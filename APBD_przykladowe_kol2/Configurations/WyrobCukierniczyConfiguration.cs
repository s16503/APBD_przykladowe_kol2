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


            //builder.HasMany(e => e.zamowienia_wyrobycukiernicze)
            //.withone(e => e.wyrobcukierniczy)
            //.hasforeignkey(e => e.idwyrobucukierniczego);
        }


    }
}
