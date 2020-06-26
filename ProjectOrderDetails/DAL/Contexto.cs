using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProjectOrderDetails.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOrderDetails.DAL
{
    public class Contexto :DbContext
    {
        public DbSet<Productos> Producto { get; set; }
        public DbSet<Suplidores> Suplidor { get; set; }
        public DbSet<Ordenes> Orden { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= C:\Base de datos\Ordenes.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Suplidores>().HasData(new Suplidores
            {
                suplidorId = 1,
                Nombre = "La sirena"
            });

            modelBuilder.Entity<Productos>().HasData(new Productos 
            { 
               productoId = 1,
               descripcion = "Malta morena",
               costo = 50.00,
               inventario = 100,
            });
        }
    }
}
