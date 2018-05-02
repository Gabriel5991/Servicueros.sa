using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ServicuerosSA.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clasificacion",
                columns: table => new
                {
                    ClasificacionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Selecciones = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clasificacion", x => x.ClasificacionId);
                });

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    ProveedorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Apellidos = table.Column<string>(maxLength: 255, nullable: false),
                    Celular = table.Column<string>(maxLength: 17, nullable: false),
                    Direccion = table.Column<string>(maxLength: 255, nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Estado = table.Column<bool>(nullable: false),
                    Fechaingreso = table.Column<DateTime>(nullable: false),
                    Nombres = table.Column<string>(maxLength: 255, nullable: false),
                    Ruc = table.Column<int>(maxLength: 13, nullable: false),
                    Telefono = table.Column<string>(maxLength: 17, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor", x => x.ProveedorId);
                });

            migrationBuilder.CreateTable(
                name: "Sexo",
                columns: table => new
                {
                    SexoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Detalle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sexo", x => x.SexoId);
                });

            migrationBuilder.CreateTable(
                name: "TipoBodega",
                columns: table => new
                {
                    TipoBodegaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Detalle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoBodega", x => x.TipoBodegaId);
                });

            migrationBuilder.CreateTable(
                name: "TipoPiel",
                columns: table => new
                {
                    TipoPielId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Detalle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPiel", x => x.TipoPielId);
                });

            migrationBuilder.CreateTable(
                name: "Personal",
                columns: table => new
                {
                    PersonalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Apellidos = table.Column<string>(nullable: true),
                    Cedula = table.Column<string>(nullable: true),
                    Celular = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    FechaNacimiento = table.Column<DateTime>(nullable: false),
                    Nombres = table.Column<string>(nullable: true),
                    SexoId = table.Column<int>(nullable: false),
                    Telefono = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personal", x => x.PersonalId);
                    table.ForeignKey(
                        name: "FK_Personal_Sexo_SexoId",
                        column: x => x.SexoId,
                        principalTable: "Sexo",
                        principalColumn: "SexoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bodega",
                columns: table => new
                {
                    BodegaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CantidadAlmacenamiento = table.Column<int>(nullable: false),
                    NombreBodega = table.Column<string>(nullable: true),
                    NumeroEstantes = table.Column<int>(nullable: false),
                    TipoBodegaId = table.Column<int>(nullable: false),
                    Ubicacion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bodega", x => x.BodegaId);
                    table.ForeignKey(
                        name: "FK_Bodega_TipoBodega_TipoBodegaId",
                        column: x => x.TipoBodegaId,
                        principalTable: "TipoBodega",
                        principalColumn: "TipoBodegaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lote",
                columns: table => new
                {
                    LoteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Codigolote = table.Column<string>(nullable: false),
                    Fechaingreso = table.Column<DateTime>(nullable: false),
                    Numerodepieles = table.Column<int>(nullable: false),
                    Observaciones = table.Column<string>(nullable: true),
                    PersonalId = table.Column<int>(nullable: false),
                    TipoPielId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lote", x => x.LoteId);
                    table.ForeignKey(
                        name: "FK_Lote_Personal_PersonalId",
                        column: x => x.PersonalId,
                        principalTable: "Personal",
                        principalColumn: "PersonalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lote_TipoPiel_TipoPielId",
                        column: x => x.TipoPielId,
                        principalTable: "TipoPiel",
                        principalColumn: "TipoPielId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bodega1",
                columns: table => new
                {
                    Bodega1Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BodegaId = table.Column<int>(nullable: false),
                    Fechaingreso = table.Column<DateTime>(nullable: false),
                    NumeroEstanteria = table.Column<int>(nullable: false),
                    Observaciones = table.Column<string>(nullable: true),
                    Peso = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bodega1", x => x.Bodega1Id);
                    table.ForeignKey(
                        name: "FK_Bodega1_Bodega_BodegaId",
                        column: x => x.BodegaId,
                        principalTable: "Bodega",
                        principalColumn: "BodegaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Proveedor_Lote",
                columns: table => new
                {
                    Proveedor_LoteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LoteId = table.Column<int>(nullable: false),
                    ProveedorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor_Lote", x => x.Proveedor_LoteId);
                    table.ForeignKey(
                        name: "FK_Proveedor_Lote_Lote_LoteId",
                        column: x => x.LoteId,
                        principalTable: "Lote",
                        principalColumn: "LoteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Proveedor_Lote_Proveedor_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedor",
                        principalColumn: "ProveedorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bodega_TipoBodegaId",
                table: "Bodega",
                column: "TipoBodegaId");

            migrationBuilder.CreateIndex(
                name: "IX_Bodega1_BodegaId",
                table: "Bodega1",
                column: "BodegaId");

            migrationBuilder.CreateIndex(
                name: "IX_Lote_PersonalId",
                table: "Lote",
                column: "PersonalId");

            migrationBuilder.CreateIndex(
                name: "IX_Lote_TipoPielId",
                table: "Lote",
                column: "TipoPielId");

            migrationBuilder.CreateIndex(
                name: "IX_Personal_SexoId",
                table: "Personal",
                column: "SexoId");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedor_Lote_LoteId",
                table: "Proveedor_Lote",
                column: "LoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedor_Lote_ProveedorId",
                table: "Proveedor_Lote",
                column: "ProveedorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bodega1");

            migrationBuilder.DropTable(
                name: "Clasificacion");

            migrationBuilder.DropTable(
                name: "Proveedor_Lote");

            migrationBuilder.DropTable(
                name: "Bodega");

            migrationBuilder.DropTable(
                name: "Lote");

            migrationBuilder.DropTable(
                name: "Proveedor");

            migrationBuilder.DropTable(
                name: "TipoBodega");

            migrationBuilder.DropTable(
                name: "Personal");

            migrationBuilder.DropTable(
                name: "TipoPiel");

            migrationBuilder.DropTable(
                name: "Sexo");
        }
    }
}
