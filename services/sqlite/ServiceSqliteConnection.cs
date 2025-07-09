using Microsoft.Data.Sqlite;

public class ServiceSqliteConnection
{
    private readonly string _connectionString;

    public ServiceSqliteConnection()
    {
        _connectionString = "Data Source=loja_carros.db";
    }

    public SqliteConnection GetConnection()
    {
        var connection = new SqliteConnection(_connectionString);
        connection.Open();
        return connection;
    }
}


