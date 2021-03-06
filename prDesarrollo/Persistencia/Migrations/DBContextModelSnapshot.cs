// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Persistencia.Migrations
{
    [DbContext(typeof(DBContext))]
    partial class DBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Cliente", b =>
                {
                    b.Property<Guid>("codCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("codCliente");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Descuento", b =>
                {
                    b.Property<Guid>("codDescuento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("codDescuento");

                    b.ToTable("Descuento");
                });

            modelBuilder.Entity("DescuentoFactura", b =>
                {
                    b.Property<Guid>("codDescuento")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("codFactura")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("descuentocodDescuento")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("facturacodFactura")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("codDescuento", "codFactura");

                    b.HasIndex("descuentocodDescuento");

                    b.HasIndex("facturacodFactura");

                    b.ToTable("DescuentoFactura");
                });

            modelBuilder.Entity("Factura", b =>
                {
                    b.Property<Guid>("codFactura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("clientecodCliente")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("codCliente")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("fechaEmision")
                        .HasColumnType("datetime2");

                    b.Property<string>("serie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("total")
                        .HasColumnType("decimal(12,2)");

                    b.HasKey("codFactura");

                    b.HasIndex("clientecodCliente");

                    b.ToTable("Factura");
                });

            modelBuilder.Entity("Pago", b =>
                {
                    b.Property<Guid>("codPago")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("codFactura")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("facturacodFactura")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("fechaPago")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("monto")
                        .HasColumnType("decimal(12,2)");

                    b.HasKey("codPago");

                    b.HasIndex("facturacodFactura");

                    b.ToTable("Pago");
                });

            modelBuilder.Entity("Paquete", b =>
                {
                    b.Property<Guid>("codPaquete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("clientecodCliente")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("codCliente")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("fechaAlta")
                        .HasColumnType("datetime2");

                    b.HasKey("codPaquete");

                    b.HasIndex("clientecodCliente");

                    b.ToTable("Paquete");
                });

            modelBuilder.Entity("PaqueteServicio", b =>
                {
                    b.Property<Guid>("codPaquete")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("codServicio")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("paquetecodPaquete")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("serviciocodServicio")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("codPaquete", "codServicio");

                    b.HasIndex("paquetecodPaquete");

                    b.HasIndex("serviciocodServicio");

                    b.ToTable("PaqueteServicio");
                });

            modelBuilder.Entity("Servicio", b =>
                {
                    b.Property<Guid>("codServicio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("codTipoServicio")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("tipoServiciocodTipoServicio")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("codServicio");

                    b.HasIndex("tipoServiciocodTipoServicio");

                    b.ToTable("Servicio");
                });

            modelBuilder.Entity("TipoServicio", b =>
                {
                    b.Property<Guid>("codTipoServicio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("codTipoServicio");

                    b.ToTable("TipoServicio");
                });

            modelBuilder.Entity("DescuentoFactura", b =>
                {
                    b.HasOne("Descuento", "descuento")
                        .WithMany("descuentoFactura")
                        .HasForeignKey("descuentocodDescuento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Factura", "factura")
                        .WithMany("descuentosFactura")
                        .HasForeignKey("facturacodFactura")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("descuento");

                    b.Navigation("factura");
                });

            modelBuilder.Entity("Factura", b =>
                {
                    b.HasOne("Cliente", "cliente")
                        .WithMany("facturas")
                        .HasForeignKey("clientecodCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cliente");
                });

            modelBuilder.Entity("Pago", b =>
                {
                    b.HasOne("Factura", "factura")
                        .WithMany("pagos")
                        .HasForeignKey("facturacodFactura")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("factura");
                });

            modelBuilder.Entity("Paquete", b =>
                {
                    b.HasOne("Cliente", "cliente")
                        .WithMany("paquetes")
                        .HasForeignKey("clientecodCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cliente");
                });

            modelBuilder.Entity("PaqueteServicio", b =>
                {
                    b.HasOne("Paquete", "paquete")
                        .WithMany("paqueteServicios")
                        .HasForeignKey("paquetecodPaquete")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Servicio", "servicio")
                        .WithMany("paqueteServicios")
                        .HasForeignKey("serviciocodServicio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("paquete");

                    b.Navigation("servicio");
                });

            modelBuilder.Entity("Servicio", b =>
                {
                    b.HasOne("TipoServicio", "tipoServicio")
                        .WithMany("servicios")
                        .HasForeignKey("tipoServiciocodTipoServicio");

                    b.Navigation("tipoServicio");
                });

            modelBuilder.Entity("Cliente", b =>
                {
                    b.Navigation("facturas");

                    b.Navigation("paquetes");
                });

            modelBuilder.Entity("Descuento", b =>
                {
                    b.Navigation("descuentoFactura");
                });

            modelBuilder.Entity("Factura", b =>
                {
                    b.Navigation("descuentosFactura");

                    b.Navigation("pagos");
                });

            modelBuilder.Entity("Paquete", b =>
                {
                    b.Navigation("paqueteServicios");
                });

            modelBuilder.Entity("Servicio", b =>
                {
                    b.Navigation("paqueteServicios");
                });

            modelBuilder.Entity("TipoServicio", b =>
                {
                    b.Navigation("servicios");
                });
#pragma warning restore 612, 618
        }
    }
}
