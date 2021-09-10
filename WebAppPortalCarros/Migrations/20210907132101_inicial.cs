using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppPortalCarros.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NIF = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: true),
                    Deletado = table.Column<bool>(type: "bit", nullable: true),
                    ModificadoEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteID);
                });

            migrationBuilder.CreateTable(
                name: "Cores",
                columns: table => new
                {
                    CorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PaletaCodigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: true),
                    Deletado = table.Column<bool>(type: "bit", nullable: true),
                    ModificadoEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cores", x => x.CorID);
                });

            migrationBuilder.CreateTable(
                name: "Donos",
                columns: table => new
                {
                    DonoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NIF = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: true),
                    Deletado = table.Column<bool>(type: "bit", nullable: true),
                    ModificadoEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donos", x => x.DonoID);
                });

            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    MarcaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeMarca = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: true),
                    Deletado = table.Column<bool>(type: "bit", nullable: true),
                    ModificadoEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.MarcaID);
                });

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    PaisID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomePais = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: true),
                    Deletado = table.Column<bool>(type: "bit", nullable: true),
                    ModificadoEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.PaisID);
                });

            migrationBuilder.CreateTable(
                name: "Unidades",
                columns: table => new
                {
                    UnidadeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeUnidade = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: true),
                    Deletado = table.Column<bool>(type: "bit", nullable: true),
                    ModificadoEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unidades", x => x.UnidadeID);
                });

            migrationBuilder.CreateTable(
                name: "Contactos",
                columns: table => new
                {
                    ContactoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonoID = table.Column<int>(type: "int", nullable: true),
                    ClienteID = table.Column<int>(type: "int", nullable: true),
                    SufixoContacto = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    NumeroContacto = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: true),
                    Deletado = table.Column<bool>(type: "bit", nullable: true),
                    ModificadoEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contactos", x => x.ContactoID);
                    table.ForeignKey(
                        name: "FK_Contactos_Clientes_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Clientes",
                        principalColumn: "ClienteID");
                    table.ForeignKey(
                        name: "FK_Contactos_Donos_DonoID",
                        column: x => x.DonoID,
                        principalTable: "Donos",
                        principalColumn: "DonoID");
                });

            migrationBuilder.CreateTable(
                name: "Emails",
                columns: table => new
                {
                    EmailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonoID = table.Column<int>(type: "int", nullable: true),
                    ClienteID = table.Column<int>(type: "int", nullable: true),
                    EmailDono = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: true),
                    Deletado = table.Column<bool>(type: "bit", nullable: true),
                    ModificadoEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emails", x => x.EmailID);
                    table.ForeignKey(
                        name: "FK_Emails_Clientes_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Clientes",
                        principalColumn: "ClienteID");
                    table.ForeignKey(
                        name: "FK_Emails_Donos_DonoID",
                        column: x => x.DonoID,
                        principalTable: "Donos",
                        principalColumn: "DonoID");
                });

            migrationBuilder.CreateTable(
                name: "Modelos",
                columns: table => new
                {
                    ModeloID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nomemodelo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MarcaID = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: true),
                    Deletado = table.Column<bool>(type: "bit", nullable: true),
                    ModificadoEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelos", x => x.ModeloID);
                    table.ForeignKey(
                        name: "FK_Modelos_Marcas_MarcaID",
                        column: x => x.MarcaID,
                        principalTable: "Marcas",
                        principalColumn: "MarcaID");
                });

            migrationBuilder.CreateTable(
                name: "Distritos",
                columns: table => new
                {
                    DistritoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeDistrito = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PaisID = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: true),
                    Deletado = table.Column<bool>(type: "bit", nullable: true),
                    ModificadoEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distritos", x => x.DistritoID);
                    table.ForeignKey(
                        name: "FK_Distritos_Paises_PaisID",
                        column: x => x.PaisID,
                        principalTable: "Paises",
                        principalColumn: "PaisID");
                });

            migrationBuilder.CreateTable(
                name: "Combustiveis",
                columns: table => new
                {
                    CombustivelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCombustivel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UnidadeID = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: true),
                    Deletado = table.Column<bool>(type: "bit", nullable: true),
                    ModificadoEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Combustiveis", x => x.CombustivelID);
                    table.ForeignKey(
                        name: "FK_Combustiveis_Unidades_UnidadeID",
                        column: x => x.UnidadeID,
                        principalTable: "Unidades",
                        principalColumn: "UnidadeID");
                });

            migrationBuilder.CreateTable(
                name: "Moradas",
                columns: table => new
                {
                    MoradaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonoID = table.Column<int>(type: "int", nullable: true),
                    ClienteID = table.Column<int>(type: "int", nullable: true),
                    Rua = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    DistritoID = table.Column<int>(type: "int", nullable: false),
                    CodigoPostal = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: true),
                    Deletado = table.Column<bool>(type: "bit", nullable: true),
                    ModificadoEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moradas", x => x.MoradaID);
                    table.ForeignKey(
                        name: "FK_Moradas_Clientes_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Clientes",
                        principalColumn: "ClienteID");
                    table.ForeignKey(
                        name: "FK_Moradas_Distritos_DistritoID",
                        column: x => x.DistritoID,
                        principalTable: "Distritos",
                        principalColumn: "DistritoID");
                    table.ForeignKey(
                        name: "FK_Moradas_Donos_DonoID",
                        column: x => x.DonoID,
                        principalTable: "Donos",
                        principalColumn: "DonoID");
                });

            migrationBuilder.CreateTable(
                name: "Carros",
                columns: table => new
                {
                    CarroID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Matricula = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Ano = table.Column<DateTime>(type: "datetime2", maxLength: 4, nullable: false),
                    Mes = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    CorID = table.Column<int>(type: "int", nullable: false),
                    CombustivelID = table.Column<int>(type: "int", nullable: false),
                    DonoID = table.Column<int>(type: "int", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Imagem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModeloID = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: true),
                    Deletado = table.Column<bool>(type: "bit", nullable: true),
                    ModificadoEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carros", x => x.CarroID);
                    table.ForeignKey(
                        name: "FK_Carros_Combustiveis_CombustivelID",
                        column: x => x.CombustivelID,
                        principalTable: "Combustiveis",
                        principalColumn: "CombustivelID");
                    table.ForeignKey(
                        name: "FK_Carros_Cores_CorID",
                        column: x => x.CorID,
                        principalTable: "Cores",
                        principalColumn: "CorID");
                    table.ForeignKey(
                        name: "FK_Carros_Donos_DonoID",
                        column: x => x.DonoID,
                        principalTable: "Donos",
                        principalColumn: "DonoID");
                    table.ForeignKey(
                        name: "FK_Carros_Modelos_ModeloID",
                        column: x => x.ModeloID,
                        principalTable: "Modelos",
                        principalColumn: "ModeloID");
                });

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    CompraID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonoID = table.Column<int>(type: "int", nullable: false),
                    ClienteID = table.Column<int>(type: "int", nullable: false),
                    CarroID = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: true),
                    Deletado = table.Column<bool>(type: "bit", nullable: true),
                    ModificadoEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.CompraID);
                    table.ForeignKey(
                        name: "FK_Compras_Carros_CarroID",
                        column: x => x.CarroID,
                        principalTable: "Carros",
                        principalColumn: "CarroID");
                    table.ForeignKey(
                        name: "FK_Compras_Clientes_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Clientes",
                        principalColumn: "ClienteID");
                    table.ForeignKey(
                        name: "FK_Compras_Donos_DonoID",
                        column: x => x.DonoID,
                        principalTable: "Donos",
                        principalColumn: "DonoID");
                });

            migrationBuilder.CreateTable(
                name: "Operacoes",
                columns: table => new
                {
                    OperacaoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeOperacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarroID = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: true),
                    Deletado = table.Column<bool>(type: "bit", nullable: true),
                    ModificadoEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operacoes", x => x.OperacaoID);
                    table.ForeignKey(
                        name: "FK_Operacoes_Carros_CarroID",
                        column: x => x.CarroID,
                        principalTable: "Carros",
                        principalColumn: "CarroID");
                });

            migrationBuilder.CreateTable(
                name: "Valores",
                columns: table => new
                {
                    ValorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrecoID = table.Column<float>(type: "real", nullable: false),
                    CarroID = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: true),
                    Deletado = table.Column<bool>(type: "bit", nullable: true),
                    ModificadoEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Valores", x => x.ValorID);
                    table.ForeignKey(
                        name: "FK_Valores_Carros_CarroID",
                        column: x => x.CarroID,
                        principalTable: "Carros",
                        principalColumn: "CarroID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carros_CarroID",
                table: "Carros",
                column: "CarroID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Carros_CombustivelID",
                table: "Carros",
                column: "CombustivelID");

            migrationBuilder.CreateIndex(
                name: "IX_Carros_CorID",
                table: "Carros",
                column: "CorID");

            migrationBuilder.CreateIndex(
                name: "IX_Carros_DonoID",
                table: "Carros",
                column: "DonoID");

            migrationBuilder.CreateIndex(
                name: "IX_Carros_ModeloID",
                table: "Carros",
                column: "ModeloID");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_ClienteID",
                table: "Clientes",
                column: "ClienteID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Combustiveis_CombustivelID",
                table: "Combustiveis",
                column: "CombustivelID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Combustiveis_UnidadeID",
                table: "Combustiveis",
                column: "UnidadeID");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_CarroID",
                table: "Compras",
                column: "CarroID");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_ClienteID",
                table: "Compras",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_CompraID",
                table: "Compras",
                column: "CompraID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Compras_DonoID",
                table: "Compras",
                column: "DonoID");

            migrationBuilder.CreateIndex(
                name: "IX_Contactos_ClienteID",
                table: "Contactos",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Contactos_ContactoID",
                table: "Contactos",
                column: "ContactoID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contactos_DonoID",
                table: "Contactos",
                column: "DonoID");

            migrationBuilder.CreateIndex(
                name: "IX_Cores_CorID",
                table: "Cores",
                column: "CorID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Distritos_DistritoID",
                table: "Distritos",
                column: "DistritoID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Distritos_PaisID",
                table: "Distritos",
                column: "PaisID");

            migrationBuilder.CreateIndex(
                name: "IX_Donos_DonoID",
                table: "Donos",
                column: "DonoID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Emails_ClienteID",
                table: "Emails",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Emails_DonoID",
                table: "Emails",
                column: "DonoID");

            migrationBuilder.CreateIndex(
                name: "IX_Emails_EmailID",
                table: "Emails",
                column: "EmailID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Marcas_MarcaID",
                table: "Marcas",
                column: "MarcaID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Modelos_MarcaID",
                table: "Modelos",
                column: "MarcaID");

            migrationBuilder.CreateIndex(
                name: "IX_Modelos_ModeloID",
                table: "Modelos",
                column: "ModeloID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Moradas_ClienteID",
                table: "Moradas",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Moradas_DistritoID",
                table: "Moradas",
                column: "DistritoID");

            migrationBuilder.CreateIndex(
                name: "IX_Moradas_DonoID",
                table: "Moradas",
                column: "DonoID");

            migrationBuilder.CreateIndex(
                name: "IX_Moradas_MoradaID",
                table: "Moradas",
                column: "MoradaID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Operacoes_CarroID",
                table: "Operacoes",
                column: "CarroID");

            migrationBuilder.CreateIndex(
                name: "IX_Operacoes_OperacaoID",
                table: "Operacoes",
                column: "OperacaoID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Paises_PaisID",
                table: "Paises",
                column: "PaisID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Unidades_UnidadeID",
                table: "Unidades",
                column: "UnidadeID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Valores_CarroID",
                table: "Valores",
                column: "CarroID");

            migrationBuilder.CreateIndex(
                name: "IX_Valores_ValorID",
                table: "Valores",
                column: "ValorID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropTable(
                name: "Contactos");

            migrationBuilder.DropTable(
                name: "Emails");

            migrationBuilder.DropTable(
                name: "Moradas");

            migrationBuilder.DropTable(
                name: "Operacoes");

            migrationBuilder.DropTable(
                name: "Valores");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Distritos");

            migrationBuilder.DropTable(
                name: "Carros");

            migrationBuilder.DropTable(
                name: "Paises");

            migrationBuilder.DropTable(
                name: "Combustiveis");

            migrationBuilder.DropTable(
                name: "Cores");

            migrationBuilder.DropTable(
                name: "Donos");

            migrationBuilder.DropTable(
                name: "Modelos");

            migrationBuilder.DropTable(
                name: "Unidades");

            migrationBuilder.DropTable(
                name: "Marcas");
        }
    }
}
