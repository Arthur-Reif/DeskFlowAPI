using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeskFlowAPI.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoDasTabelasIniciais : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tb_categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeCategoria = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_chamado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tituloDoChamado = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    descricaoDoChamado = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    prioridadeDoChamado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    statusDoChamado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    nomeDeQuemSolicitou = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DataAbertura = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFechamento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SolucaoDoChamado = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_chamado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tb_chamado_Tb_categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Tb_categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tb_interacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Autor = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    mensagem = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Registro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChamadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_interacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tb_interacao_Tb_chamado_ChamadoId",
                        column: x => x.ChamadoId,
                        principalTable: "Tb_chamado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tb_chamado_CategoriaId",
                table: "Tb_chamado",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_interacao_ChamadoId",
                table: "Tb_interacao",
                column: "ChamadoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_interacao");

            migrationBuilder.DropTable(
                name: "Tb_chamado");

            migrationBuilder.DropTable(
                name: "Tb_categoria");
        }
    }
}
