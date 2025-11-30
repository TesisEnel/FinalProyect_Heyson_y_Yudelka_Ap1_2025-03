using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProyect.Migrations
{
    /// <inheritdoc />
    public partial class IniticialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserPasskeys_AspNetUsers_UserId",
                table: "AspNetUserPasskeys");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.AddColumn<string>(
                name: "Cedula",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Correo",
                table: "AspNetUsers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "EsAdmin",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Idioma",
                table: "AspNetUsers",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NombreCompleto",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Sexo",
                table: "AspNetUsers",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Solicitantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCompleto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cedula = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitantes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReciboIngreso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SolicitanteId = table.Column<int>(type: "int", nullable: false),
                    NumeroRecibo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MontoEnLetras = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Concepto = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FormaPago = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FuenteNumero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaEmision = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaConfirmacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReciboIngreso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReciboIngreso_Solicitantes_SolicitanteId",
                        column: x => x.SolicitanteId,
                        principalTable: "Solicitantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArrendamientoTerreno",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SolicitanteId = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MetrosCuadrados = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NotificarVencimiento = table.Column<bool>(type: "bit", nullable: false),
                    ReciboIngresoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArrendamientoTerreno", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArrendamientoTerreno_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArrendamientoTerreno_ReciboIngreso_ReciboIngresoId",
                        column: x => x.ReciboIngresoId,
                        principalTable: "ReciboIngreso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArrendamientoTerreno_Solicitantes_SolicitanteId",
                        column: x => x.SolicitanteId,
                        principalTable: "Solicitantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConsultasIngresos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoIngreso = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MontoAcumulado = table.Column<decimal>(type: "decimal(18,2)", maxLength: 100, nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", maxLength: 8, nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "datetime2", maxLength: 8, nullable: false),
                    ReciboIngresoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultasIngresos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsultasIngresos_ReciboIngreso_ReciboIngresoId",
                        column: x => x.ReciboIngresoId,
                        principalTable: "ReciboIngreso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DerechoConstruccion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SolicitanteId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hora = table.Column<TimeSpan>(type: "time", nullable: false),
                    ReciboInspectorPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReciboIngresoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DerechoConstruccion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DerechoConstruccion_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DerechoConstruccion_ReciboIngreso_ReciboIngresoId",
                        column: x => x.ReciboIngresoId,
                        principalTable: "ReciboIngreso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DerechoConstruccion_Solicitantes_SolicitanteId",
                        column: x => x.SolicitanteId,
                        principalTable: "Solicitantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DerechoEnterramiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SolicitanteId = table.Column<int>(type: "int", nullable: false),
                    NombreFallecido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CedulaFallecido = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hora = table.Column<TimeSpan>(type: "time", nullable: false),
                    ReciboIngresoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DerechoEnterramiento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DerechoEnterramiento_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DerechoEnterramiento_ReciboIngreso_ReciboIngresoId",
                        column: x => x.ReciboIngresoId,
                        principalTable: "ReciboIngreso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DerechoEnterramiento_Solicitantes_SolicitanteId",
                        column: x => x.SolicitanteId,
                        principalTable: "Solicitantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExpedicionesCertificaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreSolicitante = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoCertificacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contenido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaSolicitud = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaEmision = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SolicitanteId = table.Column<int>(type: "int", nullable: false),
                    ReciboIngresoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpedicionesCertificaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpedicionesCertificaciones_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExpedicionesCertificaciones_ReciboIngreso_ReciboIngresoId",
                        column: x => x.ReciboIngresoId,
                        principalTable: "ReciboIngreso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExpedicionesCertificaciones_Solicitantes_SolicitanteId",
                        column: x => x.SolicitanteId,
                        principalTable: "Solicitantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Historiales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReciboIngresoId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolicitanteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historiales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Historiales_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Historiales_ReciboIngreso_ReciboIngresoId",
                        column: x => x.ReciboIngresoId,
                        principalTable: "ReciboIngreso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Historiales_Solicitantes_SolicitanteId",
                        column: x => x.SolicitanteId,
                        principalTable: "Solicitantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RegistrosDocumentacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCompleto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoDocumentacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Comentarios = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReciboNotariosRuta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SolicitanteId = table.Column<int>(type: "int", nullable: false),
                    ReciboIngresoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrosDocumentacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegistrosDocumentacion_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegistrosDocumentacion_ReciboIngreso_ReciboIngresoId",
                        column: x => x.ReciboIngresoId,
                        principalTable: "ReciboIngreso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegistrosDocumentacion_Solicitantes_SolicitanteId",
                        column: x => x.SolicitanteId,
                        principalTable: "Solicitantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Documentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoDocumento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NombreArchivo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    BlobUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    FechaSubida = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DerechoEnterramientoId = table.Column<int>(type: "int", nullable: true),
                    DerechoConstruccionId = table.Column<int>(type: "int", nullable: true),
                    ReciboIngresoId = table.Column<int>(type: "int", nullable: true),
                    RegistroDocumentacionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documentos_DerechoConstruccion_DerechoConstruccionId",
                        column: x => x.DerechoConstruccionId,
                        principalTable: "DerechoConstruccion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Documentos_DerechoEnterramiento_DerechoEnterramientoId",
                        column: x => x.DerechoEnterramientoId,
                        principalTable: "DerechoEnterramiento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Documentos_ReciboIngreso_ReciboIngresoId",
                        column: x => x.ReciboIngresoId,
                        principalTable: "ReciboIngreso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Documentos_RegistrosDocumentacion_RegistroDocumentacionId",
                        column: x => x.RegistroDocumentacionId,
                        principalTable: "RegistrosDocumentacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArrendamientoTerreno_ReciboIngresoId",
                table: "ArrendamientoTerreno",
                column: "ReciboIngresoId");

            migrationBuilder.CreateIndex(
                name: "IX_ArrendamientoTerreno_SolicitanteId",
                table: "ArrendamientoTerreno",
                column: "SolicitanteId");

            migrationBuilder.CreateIndex(
                name: "IX_ArrendamientoTerreno_UsuarioId",
                table: "ArrendamientoTerreno",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultasIngresos_ReciboIngresoId",
                table: "ConsultasIngresos",
                column: "ReciboIngresoId");

            migrationBuilder.CreateIndex(
                name: "IX_DerechoConstruccion_ReciboIngresoId",
                table: "DerechoConstruccion",
                column: "ReciboIngresoId");

            migrationBuilder.CreateIndex(
                name: "IX_DerechoConstruccion_SolicitanteId",
                table: "DerechoConstruccion",
                column: "SolicitanteId");

            migrationBuilder.CreateIndex(
                name: "IX_DerechoConstruccion_UsuarioId",
                table: "DerechoConstruccion",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_DerechoEnterramiento_ReciboIngresoId",
                table: "DerechoEnterramiento",
                column: "ReciboIngresoId");

            migrationBuilder.CreateIndex(
                name: "IX_DerechoEnterramiento_SolicitanteId",
                table: "DerechoEnterramiento",
                column: "SolicitanteId");

            migrationBuilder.CreateIndex(
                name: "IX_DerechoEnterramiento_UsuarioId",
                table: "DerechoEnterramiento",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Documentos_DerechoConstruccionId",
                table: "Documentos",
                column: "DerechoConstruccionId");

            migrationBuilder.CreateIndex(
                name: "IX_Documentos_DerechoEnterramientoId",
                table: "Documentos",
                column: "DerechoEnterramientoId");

            migrationBuilder.CreateIndex(
                name: "IX_Documentos_ReciboIngresoId",
                table: "Documentos",
                column: "ReciboIngresoId");

            migrationBuilder.CreateIndex(
                name: "IX_Documentos_RegistroDocumentacionId",
                table: "Documentos",
                column: "RegistroDocumentacionId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpedicionesCertificaciones_ReciboIngresoId",
                table: "ExpedicionesCertificaciones",
                column: "ReciboIngresoId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpedicionesCertificaciones_SolicitanteId",
                table: "ExpedicionesCertificaciones",
                column: "SolicitanteId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpedicionesCertificaciones_UsuarioId",
                table: "ExpedicionesCertificaciones",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Historiales_ReciboIngresoId",
                table: "Historiales",
                column: "ReciboIngresoId");

            migrationBuilder.CreateIndex(
                name: "IX_Historiales_SolicitanteId",
                table: "Historiales",
                column: "SolicitanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Historiales_UsuarioId",
                table: "Historiales",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ReciboIngreso_SolicitanteId",
                table: "ReciboIngreso",
                column: "SolicitanteId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosDocumentacion_ReciboIngresoId",
                table: "RegistrosDocumentacion",
                column: "ReciboIngresoId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosDocumentacion_SolicitanteId",
                table: "RegistrosDocumentacion",
                column: "SolicitanteId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosDocumentacion_UsuarioId",
                table: "RegistrosDocumentacion",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserPasskeys_AspNetUsers_UserId",
                table: "AspNetUserPasskeys",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserPasskeys_AspNetUsers_UserId",
                table: "AspNetUserPasskeys");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ArrendamientoTerreno");

            migrationBuilder.DropTable(
                name: "ConsultasIngresos");

            migrationBuilder.DropTable(
                name: "Documentos");

            migrationBuilder.DropTable(
                name: "ExpedicionesCertificaciones");

            migrationBuilder.DropTable(
                name: "Historiales");

            migrationBuilder.DropTable(
                name: "DerechoConstruccion");

            migrationBuilder.DropTable(
                name: "DerechoEnterramiento");

            migrationBuilder.DropTable(
                name: "RegistrosDocumentacion");

            migrationBuilder.DropTable(
                name: "ReciboIngreso");

            migrationBuilder.DropTable(
                name: "Solicitantes");

            migrationBuilder.DropColumn(
                name: "Cedula",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Correo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EsAdmin",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Idioma",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NombreCompleto",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Sexo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "AspNetUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserPasskeys_AspNetUsers_UserId",
                table: "AspNetUserPasskeys",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
