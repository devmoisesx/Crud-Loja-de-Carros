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
                Id TEXT PRIMARY KEY NOT NULL UNIQUE,
                Marca TEXT NOT NULL,
                Modelo TEXT NOT NULL,
                AnoFabricacao INTEGER NOT NULL,
                AnoModelo INTEGER NOT NULL,
                Km INTEGER NOT NULL,
                TipoTransmissao TEXT NOT NULL,
                Valor REAL NOT NULL,
                Cor TEXT NOT NULL,
                Chassis TEXT NOT NULL UNIQUE
            );
        ";

        using var command = new SqliteCommand(createTableSql, connection);
        command.ExecuteNonQuery();
    }

    public void CadastrarCarro(Carro carro)
    {
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        string sql = "INSERT INTO Carros (Id, Marca, Modelo, AnoFabricacao, AnoModelo, Km, TipoTransmissao, Valor, Cor, Chassis) VALUES (@Id, @Marca, @Modelo, @AnoFabricacao, @AnoModelo, @Km, @TipoTransmissao, @Valor, @Cor, @Chassis)";
        using var command = new SqliteCommand(sql, connection);

        command.Parameters.AddWithValue("@Id", Ulid.NewUlid().ToString());
        command.Parameters.AddWithValue("@Marca", carro.Marca);
        command.Parameters.AddWithValue("@Modelo", carro.Modelo);
        command.Parameters.AddWithValue("@AnoFabricacao", carro.AnoFabricacao);
        command.Parameters.AddWithValue("@AnoModelo", carro.AnoModelo);
        command.Parameters.AddWithValue("@Km", carro.Km);
        command.Parameters.AddWithValue("@TipoTransmissao", carro.Transmissao);
        command.Parameters.AddWithValue("@Valor", carro.Valor);
        command.Parameters.AddWithValue("@Cor", carro.Cor);
        command.Parameters.AddWithValue("@Chassis", carro.Chassis);

        command.ExecuteNonQuery();
    }

    public List<Carro> ListarCarros()
    {
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        string sql = "SELECT * FROM Carros;";
        using var command = new SqliteCommand(sql, connection);

        List<Carro> ListaCarros = new List<Carro>();
        Carro carro;

        using (SqliteDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                carro = new Carro
                (
                    reader.GetString(0),
                    (Carro.MarcaCarro)reader.GetInt32(1),
                    reader.GetString(2),
                    reader.GetInt32(3),
                    reader.GetInt32(4),
                    reader.GetInt32(5),
                    (Carro.TipoTransmissao)reader.GetInt32(6),
                    reader.GetFloat(7),
                    reader.GetString(8),
                    reader.GetString(9)
                );
                ListaCarros.Add(carro);
            }
        }

        return ListaCarros;
    }

    public Carro ListarCarro(string Id)
    {
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        string sql = "SELECT * FROM Carros WHERE Id = @Id";
        using var command = new SqliteCommand(sql, connection);
        command.Parameters.AddWithValue("@Id", Id);

        using var reader = command.ExecuteReader();
        if (reader.Read())
        {
            return new Carro
            (
                reader.GetString(0),
                (Carro.MarcaCarro)reader.GetInt32(1),
                reader.GetString(2),
                reader.GetInt32(3),
                reader.GetInt32(4),
                reader.GetInt32(5),
                (Carro.TipoTransmissao)reader.GetInt32(6),
                reader.GetFloat(7),
                reader.GetString(8),
                reader.GetString(9)
            );
        }
        throw new KeyNotFoundException($"Carro com ID {Id} não encontrado");
    }

}