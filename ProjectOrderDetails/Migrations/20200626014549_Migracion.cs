using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectOrderDetails.Migrations
{
    public partial class Migracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orden",
                columns: table => new
                {
                    ordenId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    fecha = table.Column<DateTime>(nullable: false),
                    suplidorId = table.Column<int>(nullable: false),
                    monto = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orden", x => x.ordenId);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    productoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    descripcion = table.Column<string>(nullable: false),
                    costo = table.Column<double>(nullable: false),
                    inventario = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.productoId);
                });

            migrationBuilder.CreateTable(
                name: "Suplidor",
                columns: table => new
                {
                    suplidorId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suplidor", x => x.suplidorId);
                });

            migrationBuilder.CreateTable(
                name: "OrdenesDetalle",
                columns: table => new
                {
                    ordenDetalleId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ordenId = table.Column<int>(nullable: false),
                    cantidad = table.Column<int>(nullable: false),
                    costo = table.Column<double>(nullable: false),
                    productId = table.Column<int>(nullable: false),
                    producto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenesDetalle", x => x.ordenDetalleId);
                    table.ForeignKey(
                        name: "FK_OrdenesDetalle_Orden_ordenId",
                        column: x => x.ordenId,
                        principalTable: "Orden",
                        principalColumn: "ordenId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Producto",
                columns: new[] { "productoId", "costo", "descripcion", "inventario" },
                values: new object[] { 1, 50.0, "Malta morena", 100 });

            migrationBuilder.InsertData(
                table: "Suplidor",
                columns: new[] { "suplidorId", "Nombre" },
                values: new object[] { 1, "La sirena" });

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesDetalle_ordenId",
                table: "OrdenesDetalle",
                column: "ordenId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdenesDetalle");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Suplidor");

            migrationBuilder.DropTable(
                name: "Orden");
        }
    }
}
