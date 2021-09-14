using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppPortalCarros.Models;

namespace WebApiCarros.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Operacao> Alugueis { get; set; }
        public DbSet<Ano> Anos { get; set; }
        public DbSet<Carro> Carros { get; set; }
        public DbSet<Cor> Cores { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Imagem> Imagens { get; set; }
        public DbSet<Combustivel> Combustiveis { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<Distrito> Distritos { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Dono> Donos { get; set; }
        public DbSet<Contacto> Contactos { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Morada> Moradas { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Unidade> Unidades { get; set; }
        public DbSet<Valor> Valores { get; set; }
    }
}

