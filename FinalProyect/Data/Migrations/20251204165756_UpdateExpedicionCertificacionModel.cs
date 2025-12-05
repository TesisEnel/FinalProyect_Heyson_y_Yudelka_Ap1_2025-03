using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProyect.Migrations
{
    /// <inheritdoc />
    public partial class UpdateExpedicionCertificacionModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ReciboIngresoId",
                table: "ExpedicionesCertificaciones",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ExpedicionCertificacionId",
                table: "Documentos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documentos_ExpedicionCertificacionId",
                table: "Documentos",
                column: "ExpedicionCertificacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documentos_ExpedicionesCertificaciones_ExpedicionCertificacionId",
                table: "Documentos",
                column: "ExpedicionCertificacionId",
                principalTable: "ExpedicionesCertificaciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documentos_ExpedicionesCertificaciones_ExpedicionCertificacionId",
                table: "Documentos");

            migrationBuilder.DropIndex(
                name: "IX_Documentos_ExpedicionCertificacionId",
                table: "Documentos");

            migrationBuilder.DropColumn(
                name: "ExpedicionCertificacionId",
                table: "Documentos");

            migrationBuilder.AlterColumn<int>(
                name: "ReciboIngresoId",
                table: "ExpedicionesCertificaciones",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
