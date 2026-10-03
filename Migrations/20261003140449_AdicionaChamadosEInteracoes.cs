using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeskFlowAPI.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaChamadosEInteracoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_chamado_Tb_categoria_CategoriaId",
                table: "Tb_chamado");

            migrationBuilder.RenameColumn(
                name: "Registro",
                table: "Tb_interacao",
                newName: "DataRegistro");

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_chamado_Tb_categoria_CategoriaId",
                table: "Tb_chamado",
                column: "CategoriaId",
                principalTable: "Tb_categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_chamado_Tb_categoria_CategoriaId",
                table: "Tb_chamado");

            migrationBuilder.RenameColumn(
                name: "DataRegistro",
                table: "Tb_interacao",
                newName: "Registro");

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_chamado_Tb_categoria_CategoriaId",
                table: "Tb_chamado",
                column: "CategoriaId",
                principalTable: "Tb_categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
