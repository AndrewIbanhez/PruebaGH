using System.ComponentModel.DataAnnotations;

public class TipoServicio{
    [Key]
    public Guid codTipoServicio{get;set;}
    public string nombre {get;set;} = null!; 
    public string descripcion {get;set;} = null!;
    public ICollection<Servicio> servicios {get;set;} = null!;
}