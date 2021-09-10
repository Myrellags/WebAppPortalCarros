﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAppPortalCarros.Data;

namespace WebAppPortalCarros.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebAppPortalCarros.Models.Carro", b =>
                {
                    b.Property<int>("CarroID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Ano")
                        .HasMaxLength(4)
                        .HasColumnType("datetime2");

                    b.Property<bool?>("Ativo")
                        .HasColumnType("bit");

                    b.Property<int>("CombustivelID")
                        .HasColumnType("int");

                    b.Property<int>("CorID")
                        .HasColumnType("int");

                    b.Property<bool?>("Deletado")
                        .HasColumnType("bit");

                    b.Property<int>("DonoID")
                        .HasColumnType("int");

                    b.Property<string>("Imagem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Marca")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Matricula")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Mes")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<int>("ModeloID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModificadoEm")
                        .HasColumnType("datetime2");

                    b.HasKey("CarroID");

                    b.HasIndex("CarroID")
                        .IsUnique();

                    b.HasIndex("CombustivelID");

                    b.HasIndex("CorID");

                    b.HasIndex("DonoID");

                    b.HasIndex("ModeloID");

                    b.ToTable("Carros");
                });

            modelBuilder.Entity("WebAppPortalCarros.Models.Cliente", b =>
                {
                    b.Property<int>("ClienteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Ativo")
                        .HasColumnType("bit");

                    b.Property<bool?>("Deletado")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModificadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("NIF")
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.HasKey("ClienteID");

                    b.HasIndex("ClienteID")
                        .IsUnique();

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("WebAppPortalCarros.Models.Combustivel", b =>
                {
                    b.Property<int>("CombustivelID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Ativo")
                        .HasColumnType("bit");

                    b.Property<bool?>("Deletado")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModificadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("NomeCombustivel")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("UnidadeID")
                        .HasColumnType("int");

                    b.HasKey("CombustivelID");

                    b.HasIndex("CombustivelID")
                        .IsUnique();

                    b.HasIndex("UnidadeID");

                    b.ToTable("Combustiveis");
                });

            modelBuilder.Entity("WebAppPortalCarros.Models.Compra", b =>
                {
                    b.Property<int>("CompraID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Ativo")
                        .HasColumnType("bit");

                    b.Property<int>("CarroID")
                        .HasColumnType("int");

                    b.Property<int>("ClienteID")
                        .HasColumnType("int");

                    b.Property<bool?>("Deletado")
                        .HasColumnType("bit");

                    b.Property<int>("DonoID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModificadoEm")
                        .HasColumnType("datetime2");

                    b.HasKey("CompraID");

                    b.HasIndex("CarroID");

                    b.HasIndex("ClienteID");

                    b.HasIndex("CompraID")
                        .IsUnique();

                    b.HasIndex("DonoID");

                    b.ToTable("Compras");
                });

            modelBuilder.Entity("WebAppPortalCarros.Models.Contacto", b =>
                {
                    b.Property<int>("ContactoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Ativo")
                        .HasColumnType("bit");

                    b.Property<int?>("ClienteID")
                        .HasColumnType("int");

                    b.Property<bool?>("Deletado")
                        .HasColumnType("bit");

                    b.Property<int?>("DonoID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModificadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("NumeroContacto")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("SufixoContacto")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("ContactoID");

                    b.HasIndex("ClienteID");

                    b.HasIndex("ContactoID")
                        .IsUnique();

                    b.HasIndex("DonoID");

                    b.ToTable("Contactos");
                });

            modelBuilder.Entity("WebAppPortalCarros.Models.Cor", b =>
                {
                    b.Property<int>("CorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Ativo")
                        .HasColumnType("bit");

                    b.Property<bool?>("Deletado")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModificadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("NomeCor")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PaletaCodigo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CorID");

                    b.HasIndex("CorID")
                        .IsUnique();

                    b.ToTable("Cores");
                });

            modelBuilder.Entity("WebAppPortalCarros.Models.Distrito", b =>
                {
                    b.Property<int>("DistritoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Ativo")
                        .HasColumnType("bit");

                    b.Property<bool?>("Deletado")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModificadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("NomeDistrito")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PaisID")
                        .HasColumnType("int");

                    b.HasKey("DistritoID");

                    b.HasIndex("DistritoID")
                        .IsUnique();

                    b.HasIndex("PaisID");

                    b.ToTable("Distritos");
                });

            modelBuilder.Entity("WebAppPortalCarros.Models.Dono", b =>
                {
                    b.Property<int>("DonoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Ativo")
                        .HasColumnType("bit");

                    b.Property<bool?>("Deletado")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModificadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("NIF")
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<string>("Nome")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("DonoID");

                    b.HasIndex("DonoID")
                        .IsUnique();

                    b.ToTable("Donos");
                });

            modelBuilder.Entity("WebAppPortalCarros.Models.Email", b =>
                {
                    b.Property<int>("EmailID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Ativo")
                        .HasColumnType("bit");

                    b.Property<int?>("ClienteID")
                        .HasColumnType("int");

                    b.Property<bool?>("Deletado")
                        .HasColumnType("bit");

                    b.Property<int?>("DonoID")
                        .HasColumnType("int");

                    b.Property<string>("EmailDono")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("ModificadoEm")
                        .HasColumnType("datetime2");

                    b.HasKey("EmailID");

                    b.HasIndex("ClienteID");

                    b.HasIndex("DonoID");

                    b.HasIndex("EmailID")
                        .IsUnique();

                    b.ToTable("Emails");
                });

            modelBuilder.Entity("WebAppPortalCarros.Models.Marca", b =>
                {
                    b.Property<int>("MarcaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Ativo")
                        .HasColumnType("bit");

                    b.Property<bool?>("Deletado")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModificadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("NomeMarca")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MarcaID");

                    b.HasIndex("MarcaID")
                        .IsUnique();

                    b.ToTable("Marcas");
                });

            modelBuilder.Entity("WebAppPortalCarros.Models.Modelo", b =>
                {
                    b.Property<int>("ModeloID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Ativo")
                        .HasColumnType("bit");

                    b.Property<bool?>("Deletado")
                        .HasColumnType("bit");

                    b.Property<int>("MarcaID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModificadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nomemodelo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ModeloID");

                    b.HasIndex("MarcaID");

                    b.HasIndex("ModeloID")
                        .IsUnique();

                    b.ToTable("Modelos");
                });

            modelBuilder.Entity("WebAppPortalCarros.Models.Morada", b =>
                {
                    b.Property<int>("MoradaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Ativo")
                        .HasColumnType("bit");

                    b.Property<int?>("ClienteID")
                        .HasColumnType("int");

                    b.Property<string>("CodigoPostal")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<bool?>("Deletado")
                        .HasColumnType("bit");

                    b.Property<int>("DistritoID")
                        .HasColumnType("int");

                    b.Property<int?>("DonoID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModificadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("Numero")
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<string>("Pais")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Rua")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("MoradaID");

                    b.HasIndex("ClienteID");

                    b.HasIndex("DistritoID");

                    b.HasIndex("DonoID");

                    b.HasIndex("MoradaID")
                        .IsUnique();

                    b.ToTable("Moradas");
                });

            modelBuilder.Entity("WebAppPortalCarros.Models.Operacao", b =>
                {
                    b.Property<int>("OperacaoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Ativo")
                        .HasColumnType("bit");

                    b.Property<int>("CarroID")
                        .HasColumnType("int");

                    b.Property<bool?>("Deletado")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModificadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("NomeOperacao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OperacaoID");

                    b.HasIndex("CarroID");

                    b.HasIndex("OperacaoID")
                        .IsUnique();

                    b.ToTable("Operacoes");
                });

            modelBuilder.Entity("WebAppPortalCarros.Models.Pais", b =>
                {
                    b.Property<int>("PaisID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Ativo")
                        .HasColumnType("bit");

                    b.Property<bool?>("Deletado")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModificadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("NomePais")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("PaisID");

                    b.HasIndex("PaisID")
                        .IsUnique();

                    b.ToTable("Paises");
                });

            modelBuilder.Entity("WebAppPortalCarros.Models.Unidade", b =>
                {
                    b.Property<int>("UnidadeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Ativo")
                        .HasColumnType("bit");

                    b.Property<bool?>("Deletado")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModificadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("NomeUnidade")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("UnidadeID");

                    b.HasIndex("UnidadeID")
                        .IsUnique();

                    b.ToTable("Unidades");
                });

            modelBuilder.Entity("WebAppPortalCarros.Models.Valor", b =>
                {
                    b.Property<int>("ValorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Ativo")
                        .HasColumnType("bit");

                    b.Property<int>("CarroID")
                        .HasColumnType("int");

                    b.Property<bool?>("Deletado")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModificadoEm")
                        .HasColumnType("datetime2");

                    b.Property<float>("PrecoID")
                        .HasColumnType("real");

                    b.HasKey("ValorID");

                    b.HasIndex("CarroID");

                    b.HasIndex("ValorID")
                        .IsUnique();

                    b.ToTable("Valores");
                });

            modelBuilder.Entity("WebAppPortalCarros.Models.Carro", b =>
                {
                    b.HasOne("WebAppPortalCarros.Models.Combustivel", "Combustivel")
                        .WithMany()
                        .HasForeignKey("CombustivelID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("WebAppPortalCarros.Models.Cor", "Cor")
                        .WithMany()
                        .HasForeignKey("CorID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("WebAppPortalCarros.Models.Dono", "Dono")
                        .WithMany()
                        .HasForeignKey("DonoID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("WebAppPortalCarros.Models.Modelo", "Modelo")
                        .WithMany()
                        .HasForeignKey("ModeloID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Combustivel");

                    b.Navigation("Cor");

                    b.Navigation("Dono");

                    b.Navigation("Modelo");
                });

            modelBuilder.Entity("WebAppPortalCarros.Models.Combustivel", b =>
                {
                    b.HasOne("WebAppPortalCarros.Models.Unidade", "Unidade")
                        .WithMany()
                        .HasForeignKey("UnidadeID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Unidade");
                });

            modelBuilder.Entity("WebAppPortalCarros.Models.Compra", b =>
                {
                    b.HasOne("WebAppPortalCarros.Models.Carro", "Carro")
                        .WithMany()
                        .HasForeignKey("CarroID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("WebAppPortalCarros.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("WebAppPortalCarros.Models.Dono", "Dono")
                        .WithMany()
                        .HasForeignKey("DonoID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Carro");

                    b.Navigation("Cliente");

                    b.Navigation("Dono");
                });

            modelBuilder.Entity("WebAppPortalCarros.Models.Contacto", b =>
                {
                    b.HasOne("WebAppPortalCarros.Models.Cliente", "Cliente")
                        .WithMany("Contactos")
                        .HasForeignKey("ClienteID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("WebAppPortalCarros.Models.Dono", "Dono")
                        .WithMany("Contactos")
                        .HasForeignKey("DonoID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Cliente");

                    b.Navigation("Dono");
                });

            modelBuilder.Entity("WebAppPortalCarros.Models.Distrito", b =>
                {
                    b.HasOne("WebAppPortalCarros.Models.Pais", "Pais")
                        .WithMany()
                        .HasForeignKey("PaisID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Pais");
                });

            modelBuilder.Entity("WebAppPortalCarros.Models.Email", b =>
                {
                    b.HasOne("WebAppPortalCarros.Models.Cliente", "Cliente")
                        .WithMany("Emails")
                        .HasForeignKey("ClienteID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("WebAppPortalCarros.Models.Dono", "Dono")
                        .WithMany("Emails")
                        .HasForeignKey("DonoID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Cliente");

                    b.Navigation("Dono");
                });

            modelBuilder.Entity("WebAppPortalCarros.Models.Modelo", b =>
                {
                    b.HasOne("WebAppPortalCarros.Models.Marca", "Marca")
                        .WithMany()
                        .HasForeignKey("MarcaID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Marca");
                });

            modelBuilder.Entity("WebAppPortalCarros.Models.Morada", b =>
                {
                    b.HasOne("WebAppPortalCarros.Models.Cliente", "Cliente")
                        .WithMany("Moradas")
                        .HasForeignKey("ClienteID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("WebAppPortalCarros.Models.Distrito", "Distrito")
                        .WithMany()
                        .HasForeignKey("DistritoID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("WebAppPortalCarros.Models.Dono", "Dono")
                        .WithMany("Moradas")
                        .HasForeignKey("DonoID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Cliente");

                    b.Navigation("Distrito");

                    b.Navigation("Dono");
                });

            modelBuilder.Entity("WebAppPortalCarros.Models.Operacao", b =>
                {
                    b.HasOne("WebAppPortalCarros.Models.Carro", "Carro")
                        .WithMany()
                        .HasForeignKey("CarroID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Carro");
                });

            modelBuilder.Entity("WebAppPortalCarros.Models.Valor", b =>
                {
                    b.HasOne("WebAppPortalCarros.Models.Carro", "Carro")
                        .WithMany("Valores")
                        .HasForeignKey("CarroID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Carro");
                });

            modelBuilder.Entity("WebAppPortalCarros.Models.Carro", b =>
                {
                    b.Navigation("Valores");
                });

            modelBuilder.Entity("WebAppPortalCarros.Models.Cliente", b =>
                {
                    b.Navigation("Contactos");

                    b.Navigation("Emails");

                    b.Navigation("Moradas");
                });

            modelBuilder.Entity("WebAppPortalCarros.Models.Dono", b =>
                {
                    b.Navigation("Contactos");

                    b.Navigation("Emails");

                    b.Navigation("Moradas");
                });
#pragma warning restore 612, 618
        }
    }
}
