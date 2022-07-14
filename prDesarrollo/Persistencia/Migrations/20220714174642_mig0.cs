using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Migrations
{
    public partial class mig0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    codCliente = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.codCliente);
                });

            migrationBuilder.CreateTable(
                name: "Descuento",
                columns: table => new
                {
                    codDescuento = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descuento", x => x.codDescuento);
                });

            migrationBuilder.CreateTable(
                name: "TipoServicio",
                columns: table => new
                {
                    codTipoServicio = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoServicio", x => x.codTipoServicio);
                });

            migrationBuilder.CreateTable(
                name: "Factura",
                columns: table => new
                {
                    codFactura = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fechaEmision = table.Column<DateTime>(type: "datetime2", nullable: false),
                    total = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    serie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    codCliente = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    clientecodCliente = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factura", x => x.codFactura);
                    table.ForeignKey(
                        name: "FK_Factura_Cliente_clientecodCliente",
                        column: x => x.clientecodCliente,
                        principalTable: "Cliente",
                        principalColumn: "codCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Paquete",
                columns: table => new
                {
                    codPaquete = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fechaAlta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    codCliente = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    clientecodCliente = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paquete", x => x.codPaquete);
                    table.ForeignKey(
                        name: "FK_Paquete_Cliente_clientecodCliente",
                        column: x => x.clientecodCliente,
                        principalTable: "Cliente",
                        principalColumn: "codCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Servicio",
                columns: table => new
                {
                    codServicio = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    codTipoServicio = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    tipoServiciocodTipoServicio = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicio", x => x.codServicio);
                    table.ForeignKey(
                        name: "FK_Servicio_TipoServicio_tipoServiciocodTipoServicio",
                        column: x => x.tipoServiciocodTipoServicio,
                        principalTable: "TipoServicio",
                        principalColumn: "codTipoServicio");
                });

            migrationBuilder.CreateTable(
                name: "DescuentoFactura",
                columns: table => new
                {
                    codDescuento = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    codFactura = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    descuentocodDescuento = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    facturacodFactura = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DescuentoFactura", x => new { x.codDescuento, x.codFactura });
                    table.ForeignKey(
                        name: "FK_DescuentoFactura_Descuento_descuentocodDescuento",
                        column: x => x.descuentocodDescuento,
                        principalTable: "Descuento",
                        principalColumn: "codDescuento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DescuentoFactura_Factura_facturacodFactura",
                        column: x => x.facturacodFactura,
                        principalTable: "Factura",
                        principalColumn: "codFactura",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pago",
                columns: table => new
                {
                    codPago = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fechaPago = table.Column<DateTime>(type: "datetime2", nullable: false),
                    monto = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    codFactura = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    facturacodFactura = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pago", x => x.codPago);
                    table.ForeignKey(
                        name: "FK_Pago_Factura_facturacodFactura",
                        column: x => x.facturacodFactura,
                        principalTable: "Factura",
                        principalColumn: "codFactura",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaqueteServicio",
                columns: table => new
                {
                    codPaquete = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    codServicio = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    paquetecodPaquete = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    serviciocodServicio = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaqueteServicio", x => new { x.codPaquete, x.codServicio });
                    table.ForeignKey(
                        name: "FK_PaqueteServicio_Paquete_paquetecodPaquete",
                        column: x => x.paquetecodPaquete,
                        principalTable: "Paquete",
                        principalColumn: "codPaquete",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaqueteServicio_Servicio_serviciocodServicio",
                        column: x => x.serviciocodServicio,
                        principalTable: "Servicio",
                        principalColumn: "codServicio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DescuentoFactura_descuentocodDescuento",
                table: "DescuentoFactura",
                column: "descuentocodDescuento");

            migrationBuilder.CreateIndex(
                name: "IX_DescuentoFactura_facturacodFactura",
                table: "DescuentoFactura",
                column: "facturacodFactura");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_clientecodCliente",
                table: "Factura",
                column: "clientecodCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Pago_facturacodFactura",
                table: "Pago",
                column: "facturacodFactura");

            migrationBuilder.CreateIndex(
                name: "IX_Paquete_clientecodCliente",
                table: "Paquete",
                column: "clientecodCliente");

            migrationBuilder.CreateIndex(
                name: "IX_PaqueteServicio_paquetecodPaquete",
                table: "PaqueteServicio",
                column: "paquetecodPaquete");

            migrationBuilder.CreateIndex(
                name: "IX_PaqueteServicio_serviciocodServicio",
                table: "PaqueteServicio",
                column: "serviciocodServicio");

            migrationBuilder.CreateIndex(
                name: "IX_Servicio_tipoServiciocodTipoServicio",
                table: "Servicio",
                column: "tipoServiciocodTipoServicio");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DescuentoFactura");

            migrationBuilder.DropTable(
                name: "Pago");

            migrationBuilder.DropTable(
                name: "PaqueteServicio");

            migrationBuilder.DropTable(
                name: "Descuento");

            migrationBuilder.DropTable(
                name: "Factura");

            migrationBuilder.DropTable(
                name: "Paquete");

            migrationBuilder.DropTable(
                name: "Servicio");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "TipoServicio");
        }
    }
}
