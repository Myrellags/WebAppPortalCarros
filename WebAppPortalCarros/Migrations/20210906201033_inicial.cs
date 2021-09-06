using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppPortalCarros.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Donos",
                columns: table => new
                {
                    DonoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NIF = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: true),
                    Delete = table.Column<bool>(type: "bit", nullable: true),
                    ModificadoEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donos", x => x.DonoID);
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
                    Cor = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Combustível = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DonoID = table.Column<int>(type: "int", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Imagem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modelo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: true),
                    Delete = table.Column<bool>(type: "bit", nullable: true),
                    ModificadoEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carros", x => x.CarroID);
                    table.ForeignKey(
                        name: "FK_Carros_Donos_DonoID",
                        column: x => x.DonoID,
                        principalTable: "Donos",
                        principalColumn: "DonoID");
                });

            migrationBuilder.CreateTable(
                name: "Contactos",
                columns: table => new
                {
                    ContactoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonoID = table.Column<int>(type: "int", nullable: false),
                    SufixoContacto = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    NumeroContacto = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: true),
                    Delete = table.Column<bool>(type: "bit", nullable: true),
                    ModificadoEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contactos", x => x.ContactoID);
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
                    DonoID = table.Column<int>(type: "int", nullable: false),
                    EmailDono = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: true),
                    Delete = table.Column<bool>(type: "bit", nullable: true),
                    ModificadoEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emails", x => x.EmailID);
                    table.ForeignKey(
                        name: "FK_Emails_Donos_DonoID",
                        column: x => x.DonoID,
                        principalTable: "Donos",
                        principalColumn: "DonoID");
                });

            migrationBuilder.CreateTable(
                name: "Moradas",
                columns: table => new
                {
                    MoradaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonoID = table.Column<int>(type: "int", nullable: false),
                    Rua = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    Distrito = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CodigoPostal = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: true),
                    Delete = table.Column<bool>(type: "bit", nullable: true),
                    ModificadoEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moradas", x => x.MoradaID);
                    table.ForeignKey(
                        name: "FK_Moradas_Donos_DonoID",
                        column: x => x.DonoID,
                        principalTable: "Donos",
                        principalColumn: "DonoID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carros_CarroID",
                table: "Carros",
                column: "CarroID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Carros_DonoID",
                table: "Carros",
                column: "DonoID");

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
                name: "IX_Donos_DonoID",
                table: "Donos",
                column: "DonoID",
                unique: true);

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
                name: "IX_Moradas_DonoID",
                table: "Moradas",
                column: "DonoID");

            migrationBuilder.CreateIndex(
                name: "IX_Moradas_MoradaID",
                table: "Moradas",
                column: "MoradaID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carros");

            migrationBuilder.DropTable(
                name: "Contactos");

            migrationBuilder.DropTable(
                name: "Emails");

            migrationBuilder.DropTable(
                name: "Moradas");

            migrationBuilder.DropTable(
                name: "Donos");
        }
    }
}
