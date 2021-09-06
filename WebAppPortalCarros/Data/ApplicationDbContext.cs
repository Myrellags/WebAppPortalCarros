using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppPortalCarros.Models;

namespace WebAppPortalCarros.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Carro> Carros { get; set; }
        public DbSet<Dono> Donos { get; set; }
        public DbSet<Contacto> Contactos { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Morada> Moradas { get; set; }

        #region "Enforce On Delete ForeignKey"
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.NoAction;
            }
        }
        #endregion
    }
}
