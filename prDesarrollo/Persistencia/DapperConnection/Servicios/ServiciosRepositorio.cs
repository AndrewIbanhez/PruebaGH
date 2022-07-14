using System.Data;
using Dapper;

public class ServiciosRepositorio : IServicio
{
    private readonly IFactoryConnection factoryConnection;

    public ServiciosRepositorio(IFactoryConnection factoryConnection){
        this.factoryConnection = factoryConnection;
    }

    public async Task<int> ActualizarServicio(Guid codServicio, string nombre, string descripcion)
    {
        var storeProcedure = "spActualizarServicio";
        try{
            var connection = factoryConnection.GetConnection(); 
            var resultado = await connection.ExecuteAsync(
                storeProcedure, 
                new {
                    codServicio = codServicio, 
                    nombre = nombre, 
                    descripcion = descripcion
                }, 
                commandType : CommandType.StoredProcedure
            );

            connection.Close(); 
            return resultado;
        }
        catch(Exception e){
            throw new Exception("No se pudo actualizar el registro", e);
        }
    }

    public async Task<int> CrearServicio(string nombre, string descripcion)
    {
        var storeProcedure = "spCrearServicio";
        try
        {
            var connection = factoryConnection.GetConnection();
            var resultado = await connection.ExecuteAsync(
                storeProcedure, 
                new{
                    codServicio = Guid.NewGuid(),
                    nombre = nombre, 
                    descripcion = descripcion
                }, 
                commandType : CommandType.StoredProcedure
            );

            factoryConnection.CloseConnection();
            return resultado;
        }
        catch (Exception e)
        {            
            throw new Exception("No se pudo guardar el nuevo registro", e);
        }
    }

    public async Task<int> EliminarServicio(Guid id)
    {
        var storeProcedure = "spEliminarServicio";
        try{
            var connection = factoryConnection.GetConnection();
            var resultado = await connection.ExecuteAsync(
                storeProcedure, 
                new{
                    codServicio = id
                }, 
                commandType : CommandType.StoredProcedure
            );

            factoryConnection.CloseConnection();
            return resultado;
        }
        catch (Exception e)
        {            
            throw new Exception("No se pudo eliminar el registro", e);
        }
    }

    public async Task<IEnumerable<ServicioModel>> ObtenerServicios()
    {
        IEnumerable<ServicioModel> serviciosList = null;
        var storeProcedure = "spObtenerServicios";

        try{
            var connection = factoryConnection.GetConnection(); 
            serviciosList = await connection.QueryAsync<ServicioModel>(
                storeProcedure,
                null, 
                commandType : System.Data.CommandType.StoredProcedure
            );
        }
        catch (Exception e){
            
            throw new Exception("Error en la consulta de datos", e);
        }
        finally{
            factoryConnection.CloseConnection();
        }

        return serviciosList;
    }

    public Task<ServicioModel> ObtenerServicioxId(Guid id)
    {
        throw new NotImplementedException();
    }
}