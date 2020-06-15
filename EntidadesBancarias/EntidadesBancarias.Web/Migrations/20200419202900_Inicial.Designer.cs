﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using EntidadesBancarias.Datos;

namespace EntidadesBancarias.Web.Migrations
{
    [DbContext(typeof(EntidadesBancariasContext))]
    [Migration("20200419202900_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EntidadesBancarias.Entidades.EntidadBancaria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodPostal")
                        .IsRequired()
                        .HasMaxLength(5);

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<bool>("EstadoActivo");

                    b.Property<int?>("GrupoEntidadID")
                        .IsRequired();

                    b.Property<string>("Logo");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Pais")
                        .HasMaxLength(50);

                    b.Property<string>("Poblacion")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Provincia")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("Telefono");

                    b.HasKey("Id");

                    b.HasIndex("GrupoEntidadID");

                    b.ToTable("EntidadBancaria");
                });

            modelBuilder.Entity("EntidadesBancarias.Entidades.GrupoEntidad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Color")
                        .HasMaxLength(50);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("GrupoEntidad");
                });

            modelBuilder.Entity("EntidadesBancarias.Entidades.EntidadBancaria", b =>
                {
                    b.HasOne("EntidadesBancarias.Entidades.GrupoEntidad", "GrupoEntidad")
                        .WithMany("EntidadBancaria")
                        .HasForeignKey("GrupoEntidadID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
