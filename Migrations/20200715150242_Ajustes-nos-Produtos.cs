using Microsoft.EntityFrameworkCore.Migrations;

namespace ExemploLojinha.Migrations
{
    public partial class AjustesnosProdutos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Notas_NotaId",
                table: "Produto");

            migrationBuilder.AlterColumn<int>(
                name: "NotaId",
                table: "Produto",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Notas_NotaId",
                table: "Produto",
                column: "NotaId",
                principalTable: "Notas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Notas_NotaId",
                table: "Produto");

            migrationBuilder.AlterColumn<int>(
                name: "NotaId",
                table: "Produto",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Notas_NotaId",
                table: "Produto",
                column: "NotaId",
                principalTable: "Notas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
