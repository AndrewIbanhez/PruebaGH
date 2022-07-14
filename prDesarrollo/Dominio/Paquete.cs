using System.ComponentModel.DataAnnotations;

public class Paquete{
    [Key]
    public Guid codPaquete {get;set;}
    public DateTime fechaAlta {get;set;}
    public string direccion {get;set;}  = null!;
    public Guid codCliente {get;set;}
    public Cliente cliente {get;set;}  = null!;
    public ICollection<PaqueteServicio> paqueteServicios {get;set;}  = null!;
}