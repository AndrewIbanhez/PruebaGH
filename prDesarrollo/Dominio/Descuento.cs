using System.ComponentModel.DataAnnotations;

public class Descuento{
    [Key]
    public Guid codDescuento {get;set;}
    public string nombre {get;set;} = null!;
    public string descripcion{get;set;} = null!;
    public ICollection<DescuentoFactura> descuentoFactura {get;set;}  = null!;
}