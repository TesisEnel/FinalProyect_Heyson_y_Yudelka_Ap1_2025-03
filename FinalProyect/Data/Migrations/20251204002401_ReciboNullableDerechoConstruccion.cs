using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProyect.Migrations
{
    /// <inheritdoc />
    public partial class ReciboNullableDerechoConstruccion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ReciboIngresoId",
                table: "DerechoConstruccion",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ReciboIngresoId",
                table: "DerechoConstruccion",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
