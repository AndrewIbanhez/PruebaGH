using System.Data;

public interface IFactoryConnection {
    void CloseConnection(); 
    IDbConnection GetConnection();
}