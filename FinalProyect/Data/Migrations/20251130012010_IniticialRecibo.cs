using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProyect.Migrations
{
    /// <inheritdoc />
    public partial class IniticialRecibo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoProceso",
                table: "RegistrosDocumentacion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoProceso",
                table: "ExpedicionesCertificaciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoProceso",
                table: "DerechoEnterramiento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoProceso",
                table: "DerechoConstruccion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "MetrosCuadrados",
                table: "ArrendamientoTerreno",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "TipoProceso",
                table: "ArrendamientoTerreno",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Ubicacion",
                table: "ArrendamientoTerreno",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoProceso",
                table: "RegistrosDocumentacion");

            migrationBuilder.DropColumn(
                name: "TipoProceso",
                table: "ExpedicionesCertificaciones");

            migrationBuilder.DropColumn(
                name: "TipoProceso",
                table: "DerechoEnterramiento");

            migrationBuilder.DropColumn(
                name: "TipoProceso",
                table: "DerechoConstruccion");

            migrationBuilder.DropColumn(
                name: "TipoProceso",
                table: "ArrendamientoTerreno");

            migrationBuilder.DropColumn(
                name: "Ubicacion",
                table: "ArrendamientoTerreno");

            migrationBuilder.AlterColumn<decimal>(
                name: "MetrosCuadrados",
                table: "ArrendamientoTerreno",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
