using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ServicuerosSA.Migrations
{
    public partial class relaciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClasificacionId",
                table: "Bodega1",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LoteId",
                table: "Bodega1",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bodega1_ClasificacionId",
                table: "Bodega1",
                column: "ClasificacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Bodega1_LoteId",
                table: "Bodega1",
                column: "LoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bodega1_Clasificacion_ClasificacionId",
                table: "Bodega1",
                column: "ClasificacionId",
                principalTable: "Clasificacion",
                principalColumn: "ClasificacionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bodega1_Lote_LoteId",
                table: "Bodega1",
                column: "LoteId",
                principalTable: "Lote",
                principalColumn: "LoteId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bodega1_Clasificacion_ClasificacionId",
                table: "Bodega1");

            migrationBuilder.DropForeignKey(
                name: "FK_Bodega1_Lote_LoteId",
                table: "Bodega1");

            migrationBuilder.DropIndex(
                name: "IX_Bodega1_ClasificacionId",
                table: "Bodega1");

            migrationBuilder.DropIndex(
                name: "IX_Bodega1_LoteId",
                table: "Bodega1");

            migrationBuilder.DropColumn(
                name: "ClasificacionId",
                table: "Bodega1");

            migrationBuilder.DropColumn(
                name: "LoteId",
                table: "Bodega1");
        }
    }
}
