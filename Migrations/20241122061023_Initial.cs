using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gs2DotNet.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_conteudo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    Tipo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_conteudo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_estudante",
                columns: table => new
                {
                    Id = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Tipo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Senha = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_estudante", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_modulo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    Titulo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Nivel = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_modulo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_turma",
                columns: table => new
                {
                    Id = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    Nome_turma = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Ano = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_turma", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_conteudo");

            migrationBuilder.DropTable(
                name: "tb_estudante");

            migrationBuilder.DropTable(
                name: "tb_modulo");

            migrationBuilder.DropTable(
                name: "tb_turma");
        }
    }
}
