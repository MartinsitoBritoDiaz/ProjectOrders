﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectOrderDetails.DAL;

namespace ProjectOrderDetails.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20200626223819_MIgracion")]
    partial class MIgracion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5");

            modelBuilder.Entity("ProjectOrderDetails.Models.Ordenes", b =>
                {
                    b.Property<int>("ordenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("TEXT");

                    b.Property<double>("monto")
                        .HasColumnType("REAL");

                    b.Property<int>("suplidorId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ordenId");

                    b.ToTable("Orden");
                });

            modelBuilder.Entity("ProjectOrderDetails.Models.OrdenesDetalle", b =>
                {
                    b.Property<int>("ordenDetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<double>("costo")
                        .HasColumnType("REAL");

                    b.Property<int>("ordenId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("productId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("producto")
                        .HasColumnType("TEXT");

                    b.HasKey("ordenDetalleId");

                    b.HasIndex("ordenId");

                    b.ToTable("OrdenesDetalle");
                });

            modelBuilder.Entity("ProjectOrderDetails.Models.Productos", b =>
                {
                    b.Property<int>("productoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("costo")
                        .HasColumnType("REAL");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("inventario")
                        .HasColumnType("INTEGER");

                    b.HasKey("productoId");

                    b.ToTable("Producto");

                    b.HasData(
                        new
                        {
                            productoId = 1,
                            costo = 50.0,
                            descripcion = "Malta morena",
                            inventario = 100
                        });
                });

            modelBuilder.Entity("ProjectOrderDetails.Models.Suplidores", b =>
                {
                    b.Property<int>("suplidorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("suplidorId");

                    b.ToTable("Suplidor");

                    b.HasData(
                        new
                        {
                            suplidorId = 1,
                            Nombre = "La sirena"
                        });
                });

            modelBuilder.Entity("ProjectOrderDetails.Models.OrdenesDetalle", b =>
                {
                    b.HasOne("ProjectOrderDetails.Models.Ordenes", null)
                        .WithMany("OrdenesDetalles")
                        .HasForeignKey("ordenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
