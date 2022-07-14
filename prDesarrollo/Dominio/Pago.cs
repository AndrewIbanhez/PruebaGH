using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Pago{
    [Key]
    public Guid codPago {get;set;}
    public DateTime fechaPago {get;set;}
    [Column(TypeName = "decimal(12, 2)")]
    public decimal monto {get;set;}
    public Guid codFactura {get;set;}
    public Factura factura {get;set;}  = null!;
}