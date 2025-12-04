using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProyect.Migrations
{
    /// <inheritdoc />
    public partial class DocumentointoArrendamiento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArrendamientoTerrenoId",
                table: "Documentos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documentos_ArrendamientoTerrenoId",
                table: "Documentos",
                column: "ArrendamientoTerrenoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documentos_ArrendamientoTerreno_ArrendamientoTerrenoId",
                table: "Documentos",
                column: "ArrendamientoTerrenoId",
                principalTable: "ArrendamientoTerreno",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documentos_ArrendamientoTerreno_ArrendamientoTerrenoId",
                table: "Documentos");

            migrationBuilder.DropIndex(
                name: "IX_Documentos_ArrendamientoTerrenoId",
                table: "Documentos");

            migrationBuilder.DropColumn(
                name: "ArrendamientoTerrenoId",
                table: "Documentos");
        }
    }
}
