public class PaqueteServicio{
    public Guid codPaquete {get;set;}
    public Paquete paquete {get;set;} = null!;
    public Guid codServicio {get;set;}
    public Servicio servicio {get;set;}  = null!;
}