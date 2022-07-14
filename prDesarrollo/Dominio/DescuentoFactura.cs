public class DescuentoFactura{
    public Guid codDescuento {get;set;}
    public Descuento descuento {get;set;} = null!;
    public Guid codFactura {get;set;}
    public Factura factura {get;set;} = null!;
}