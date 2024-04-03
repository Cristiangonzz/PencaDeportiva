using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AngularApp1.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campionatos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campionatos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Partidos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GolLocal = table.Column<int>(type: "int", nullable: false),
                    GolVisitante = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partidos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tablas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CampionatoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tablas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tablas_Campionatos_CampionatoId",
                        column: x => x.CampionatoId,
                        principalTable: "Campionatos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    CampionatoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PartidoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipos_Campionatos_CampionatoId",
                        column: x => x.CampionatoId,
                        principalTable: "Campionatos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Equipos_Partidos_PartidoId",
                        column: x => x.PartidoId,
                        principalTable: "Partidos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Clasificacions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EquipoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Point = table.Column<int>(type: "int", nullable: false),
                    Posicion = table.Column<int>(type: "int", nullable: false),
                    PartidosJugados = table.Column<int>(type: "int", nullable: false),
                    GolesAF = table.Column<int>(type: "int", nullable: false),
                    GolesEC = table.Column<int>(type: "int", nullable: false),
                    Victorias = table.Column<int>(type: "int", nullable: false),
                    Derrotas = table.Column<int>(type: "int", nullable: false),
                    Empatados = table.Column<int>(type: "int", nullable: false),
                    TablaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clasificacions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clasificacions_Equipos_EquipoId",
                        column: x => x.EquipoId,
                        principalTable: "Equipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clasificacions_Tablas_TablaId",
                        column: x => x.TablaId,
                        principalTable: "Tablas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clasificacions_EquipoId",
                table: "Clasificacions",
                column: "EquipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Clasificacions_TablaId",
                table: "Clasificacions",
                column: "TablaId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipos_CampionatoId",
                table: "Equipos",
                column: "CampionatoId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipos_PartidoId",
                table: "Equipos",
                column: "PartidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tablas_CampionatoId",
                table: "Tablas",
                column: "CampionatoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clasificacions");

            migrationBuilder.DropTable(
                name: "Equipos");

            migrationBuilder.DropTable(
                name: "Tablas");

            migrationBuilder.DropTable(
                name: "Partidos");

            migrationBuilder.DropTable(
                name: "Campionatos");
        }
    }
}
