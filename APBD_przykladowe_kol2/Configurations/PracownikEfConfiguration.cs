﻿using APBD_przykladowe_kol2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_przykladowe_kol2.Configurations
{
    public class PracownikEfConfiguration : IEntityTypeConfiguration<Pracownik>
    {
        public void Configure(EntityTypeBuilder<Pracownik> builder)
        {
            //base.OnModelCreating(builder);

            builder.HasKey(e => e.IdPracownik);
            builder.Property(e => e.IdPracownik).ValueGeneratedOnAdd();
            builder.Property(e => e.Imie).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Nazwisko).IsRequired().HasMaxLength(60);

            builder.HasMany(e => e.Zamowienia)
                    .WithOne(e => e.Pracownik)
                    .HasForeignKey(e => e.IdPracownika);
        }


    }
}

