using Microsoft.EntityFrameworkCore;
using EntidadesBancarias.Datos.Mapping;
using EntidadesBancarias.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesBancarias.Datos
{
    public class EntidadesBancariasContext : DbContext
    {

        public EntidadesBancariasContext(DbContextOptions<EntidadesBancariasContext> options) : base(options)
        {

        }

        public DbSet<EntidadBancaria> Entidades { get; set; }
        public DbSet<GrupoEntidad> Grupos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new EntidadBancariaMap());
            modelBuilder.ApplyConfiguration(new GrupoEntidadMap());
        }
    }
}
