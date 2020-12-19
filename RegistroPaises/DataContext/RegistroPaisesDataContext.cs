using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RegistroPaises.Models;

namespace RegistroPaises.DataContext
{
    public class RegistroPaisesDataContext : DbContext
    {
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=WONG;DataBase=PaisesDB;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MapPais());
            modelBuilder.ApplyConfiguration(new MapUsuario());
            base.OnModelCreating(modelBuilder);
        }
    }
}
