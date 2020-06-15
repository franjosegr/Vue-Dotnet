using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EntidadesBancarias.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesBancarias.Datos.Mapping
{
    public class GrupoEntidadMap : IEntityTypeConfiguration<GrupoEntidad>
    {
        public void Configure(EntityTypeBuilder<GrupoEntidad> builder)
        {
            builder.ToTable("GrupoEntidad");

            builder.Property(c => c.Nombre).HasMaxLength(100);
            builder.Property(c => c.Color).HasMaxLength(50);
        }
    }
}
