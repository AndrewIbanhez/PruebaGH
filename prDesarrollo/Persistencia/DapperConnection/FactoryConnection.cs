using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

public class FactoryConnection : IFactoryConnection
{   
    private IDbConnection connection ;
    private readonly IOptions<ConexionConfiguracion> configs;
    public FactoryConnection(IOptions<ConexionConfiguracion> configs){
        this.configs = configs;
    }
    public void CloseConnection()
    {
        if(connection != null && connection.State == ConnectionState.Open)
            connection.Close();
    }

    public IDbConnection GetConnection()
    {
        if(connection == null)
            connection = new SqlConnection(configs.Value.DefaultConnection);

        if(connection.State != ConnectionState.Open)
            connection.Open();
        
        return connection;
    }
}