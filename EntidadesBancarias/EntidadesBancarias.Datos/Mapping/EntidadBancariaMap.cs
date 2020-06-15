using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EntidadesBancarias.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesBancarias.Datos.Mapping
{
    public class EntidadBancariaMap : IEntityTypeConfiguration<EntidadBancaria>
    {
        public void Configure(EntityTypeBuilder<EntidadBancaria> builder)
        {
            builder.ToTable("EntidadBancaria");

            builder.Property(c => c.Nombre).HasMaxLength(100);
            builder.Property(c => c.Direccion).HasMaxLength(250);
            builder.Property(c => c.Poblacion).HasMaxLength(100);
            builder.Property(c => c.Provincia).HasMaxLength(100);
            builder.Property(c => c.CodPostal).HasMaxLength(5);
            builder.Property(c => c.Mail).HasMaxLength(100);
            builder.Property(c => c.Pais).HasMaxLength(50);
            builder.Property(p => p.fileLogo).HasColumnType("image");
        }
    }
}
