using Microsoft.EntityFrameworkCore.Migrations;

namespace ExemploLojinha.Migrations
{
    public partial class Ajustesnasnotas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendedor_Notas_NotaId",
                table: "Vendedor");

            migrationBuilder.DropIndex(
                name: "IX_Vendedor_NotaId",
                table: "Vendedor");

            migrationBuilder.DropColumn(
                name: "NotaId",
                table: "Vendedor");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_VendedorId",
                table: "Notas",
                column: "VendedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_Vendedor_VendedorId",
                table: "Notas",
                column: "VendedorId",
                principalTable: "Vendedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notas_Vendedor_VendedorId",
                table: "Notas");

            migrationBuilder.DropIndex(
                name: "IX_Notas_VendedorId",
                table: "Notas");

            migrationBuilder.AddColumn<int>(
                name: "NotaId",
                table: "Vendedor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Vendedor_NotaId",
                table: "Vendedor",
                column: "NotaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendedor_Notas_NotaId",
                table: "Vendedor",
                column: "NotaId",
                principalTable: "Notas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
