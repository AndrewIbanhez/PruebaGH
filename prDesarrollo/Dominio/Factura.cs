using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Factura{
    [Key]
    public Guid codFactura {get;set;}
    public DateTime fechaEmision {get;set;}
    [Column(TypeName = "decimal(12, 2)")]
    public decimal total {get;set;}
    public string serie {get;set;}  = null!;
    public ICollection<DescuentoFactura> descuentosFactura {get;set;} = null!;
    public ICollection<Pago> pagos {get;set;}  = null!;
    public Guid codCliente {get;set;}
    public Cliente cliente {get;set;} = null!;
}