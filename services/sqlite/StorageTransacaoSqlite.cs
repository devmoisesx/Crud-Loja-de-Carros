using Microsoft.Data.Sqlite;

public class StorageTransacaoSqlite
{
    private readonly string _connectionString;

    public StorageTransacaoSqlite()
    {
        _connectionString = "Data Source=lojaCarros.db;";
        InitializeDatabase();
    }

    public void InitializeDatabase()
    {
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        using (var pragmaCommand = new SqliteCommand("PRAGMA foreign_keys = ON;"))
        {
            pragmaCommand.ExecuteNonQueryAsync();  
        };
        
        string createTableSql = @"
            CREATE TABLE IF NOT EXISTS Transacoes (
                Id INTEGER PRIMARY KEY,
                TipoTransacao TEXT NOT NULL,
                Valor FLOAT NOT NULL,
                Data TEXT NOT NULL,
                CarroID INTEGER NOT NULL,
                ClienteID INTEGER NOT NULL,
                FOREIGN KEY (CarroID) REFERENCES Carros (Id),
                FOREIGN KEY (ClienteID) REFERENCES Clientes (Id)
            );
        ";

        using (var command = new SqliteCommand(createTableSql, connection))
        {
            command.ExecuteNonQuery();
        };
    }

    public void InserirTransacao(Transacao transacao)
    {
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        string sql = "INSERT INTO Transacoes (Id, TipoTransacao, Valor, Data, CarroID, ClienteID) VALUES (@Id, @TipoTransacao, @Valor, @Data, @CarroID, @ClienteID)";
        using var command = new SqliteCommand(sql, connection);

        command.Parameters.AddWithValue("@Id", transacao.Id);
        command.Parameters.AddWithValue("@TipoTransacao", transacao.Tipo);
        command.Parameters.AddWithValue("@Valor", transacao.Valor);
        command.Parameters.AddWithValue("@Data", transacao.Data);
        command.Parameters.AddWithValue("@CarroID", transacao.CarroID);
        command.Parameters.AddWithValue("@ClienteID", transacao.ClienteID);

        command.ExecuteNonQuery();
    }

}