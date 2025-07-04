using Microsoft.Data.Sqlite;

public class StorageCarroSqlite
{
    private readonly string _connectionString;

    public StorageCarroSqlite()
    {
        _connectionString = "Data Source=lojaCarros.db;";
        InitializeDatabase();
    }

    public void InitializeDatabase()
    {
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        string createTableSql = @"
            CREATE TABLE IF NOT EXISTS Carros (
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

    public void CadastrarCarro(Carro carro)
    {
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        string sql = "INSERT INTO Carros (Id, Marca, Modelo, AnoFabricacao, AnoModelo, Km, TipoTransmissao, Valor, Cor, Chassis) VALUES (NULL, @Marca, @Modelo, @AnoFabricacao, @AnoModelo, @Km, @TipoTransmissao, @Valor, @Cor, @Chassis)";
        using var command = new SqliteCommand(sql, connection);

        // command.Parameters.AddWithValue("@Id", carro.Id);
        command.Parameters.AddWithValue("@Marca", carro.Marca);
        command.Parameters.AddWithValue("@Modelo", carro.Modelo);
        command.Parameters.AddWithValue("@AnoFabricacao", carro.AnoFabricacao);
        command.Parameters.AddWithValue("@AnoModelo", carro.AnoModelo);
        command.Parameters.AddWithValue("@Km", carro.Km);
        command.Parameters.AddWithValue("@TipoTransmissao", carro.Transmissao);
        command.Parameters.AddWithValue("@Valor", carro.Valor);
        command.Parameters.AddWithValue("@Cor", carro.Cor);
        command.Parameters.AddWithValue("@Chassis", carro.Chassis);
        // command.Parameters.AddWithValue("@Id", carro.);

        command.ExecuteNonQuery();
    }

}