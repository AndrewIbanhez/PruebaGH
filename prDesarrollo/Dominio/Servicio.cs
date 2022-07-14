using System.ComponentModel.DataAnnotations;

public class Servicio{
    [Key]
    public Guid codServicio {get;set;}
    public string nombre {get;set;} = null!; 
    public string descripcion {get;set;} = null!;
    public Guid? codTipoServicio {get;set;}
    public TipoServicio? tipoServicio{get;set;}
    public ICollection<PaqueteServicio>? paqueteServicios {get;set;}
}