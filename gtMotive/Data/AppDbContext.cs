using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gtMotive.Models;
using Microsoft.EntityFrameworkCore;

namespace gtMotive.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Alquiler> Alquileres { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Vehiculo>()
                .HasIndex(u => u.Matricula)
                .IsUnique(true);
        }

    }
}