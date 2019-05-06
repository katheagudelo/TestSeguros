﻿// <auto-generated />
using System;
using CapaDatos.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AccesoDatos.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity("AccesoDatos.Modelos.Poliza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Cobertura");

                    b.Property<string>("Descripcion");

                    b.Property<DateTime>("InicioVigencia");

                    b.Property<string>("Nombre");

                    b.Property<int>("Periodo");

                    b.Property<double>("PrecioPoliza");

                    b.Property<string>("TipoCubrimiento");

                    b.Property<int>("TipoRiesgo");

                    b.HasKey("Id");

                    b.ToTable("Polizas");
                });

            modelBuilder.Entity("AccesoDatos.Modelos.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("NombreUsuario");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}