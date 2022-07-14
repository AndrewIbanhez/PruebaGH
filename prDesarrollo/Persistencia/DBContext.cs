using Microsoft.EntityFrameworkCore;

public class DBContext : DbContext{
    public DBContext(DbContextOptions options) : base(options){

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder){

        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<DescuentoFactura>()
        .HasKey(x => new {x.codDescuento, x.codFactura});

        modelBuilder.Entity<PaqueteServicio>()
        .HasKey(x => new {x.codPaquete, x.codServicio});
    }

    public DbSet<Cliente> Cliente {get;set;} = null!;
    public DbSet<Descuento> Descuento {get;set;} = null!;
    public DbSet<Factura> Factura {get;set;} = null!;
    public DbSet<Pago> Pago {get;set;} = null!;
    public DbSet<Paquete> Paquete {get;set;} = null!;
    public DbSet<PaqueteServicio> PaqueteServicio {get;set;} = null!;
    public DbSet<Servicio> Servicio {get;set;} = null!;
    public DbSet<TipoServicio> TipoServicio {get;set;} = null!;
}  