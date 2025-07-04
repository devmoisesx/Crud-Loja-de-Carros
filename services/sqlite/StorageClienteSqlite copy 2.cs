using Microsoft.Data.Sqlite;

public class StorageClienteSqlite
{
    private readonly string _connectionString;

    public StorageClienteSqlite()
    {
        _connectionString = "Data Source=lojaClientes.db;";
        InitializeDatabase();
    }

    public void InitializeDatabase()
    {
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        string createTableSql = @"
            CREATE TABLE IF NOT EXISTS Clientes (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Marca TEXT NOT NULL,
                Modelo TEXT NOT NULL,
                AnoFabricacao INTEGER NOT NULL,
                AnoModelo INTEGER NOT NULL,
                Km INTEGER NOT NULL,
                TipoTransmissao TEXT NOT NULL,
                Valor REAL NOT NULL,
                Cor TEXT NOT NULL,
                Chassis TEXT NOT NULL
            );
        ";

        using var command = new SqliteCommand(createTableSql, connection);
        command.ExecuteNonQuery();
    }

    public void Cadastrarcliente(Cliente cliente)
    {
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        string sql = "INSERT INTO clientes (Id, Marca, Modelo, AnoFabricacao, AnoModelo, Km, TipoTransmissao, Valor, Cor, Chassis) VALUES (NULL, @Marca, @Modelo, @AnoFabricacao, @AnoModelo, @Km, @TipoTransmissao, @Valor, @Cor, @Chassis)";
        using var command = new SqliteCommand(sql, connection);

        // command.Parameters.AddWithValue("@Id", cliente.Id);
        command.Parameters.AddWithValue("@Marca", cliente.Marca);
        command.Parameters.AddWithValue("@Modelo", cliente.Modelo);
        command.Parameters.AddWithValue("@AnoFabricacao", cliente.AnoFabricacao);
        command.Parameters.AddWithValue("@AnoModelo", cliente.AnoModelo);
        command.Parameters.AddWithValue("@Km", cliente.Km);
        command.Parameters.AddWithValue("@TipoTransmissao", cliente.Transmissao);
        command.Parameters.AddWithValue("@Valor", cliente.Valor);
        command.Parameters.AddWithValue("@Cor", cliente.Cor);
        command.Parameters.AddWithValue("@Chassis", cliente.Chassis);
        // command.Parameters.AddWithValue("@Id", cliente.);

        command.ExecuteNonQuery();
    }

}