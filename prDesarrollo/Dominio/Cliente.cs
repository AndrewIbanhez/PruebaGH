using System.ComponentModel.DataAnnotations;

public class Cliente{
    [Key]
    public Guid codCliente {get;set;}
    public string nombre {get;set;} = null!;
    public string apellido {get;set;} = null!;
    public string direccion {get;set;} = null!; 
    public string telefono {get;set;}  = null!;
    public ICollection<Paquete> paquetes {get;set;} = null!;
    public ICollection<Factura> facturas {get;set;} = null!;
}