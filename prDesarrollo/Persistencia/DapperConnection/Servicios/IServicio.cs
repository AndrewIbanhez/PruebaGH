public interface IServicio{
    Task<IEnumerable<ServicioModel>> ObtenerServicios(); 
    Task<ServicioModel> ObtenerServicioxId(Guid id);
    Task<int> CrearServicio (string nombre, string descripcion);
    Task<int> ActualizarServicio(Guid codServicio, string nombre, string descripcion);
    Task<int> EliminarServicio(Guid id);
}