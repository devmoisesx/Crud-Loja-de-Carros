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

        using (var pragmaCommand = new SqliteCommand("PRAGMA foreign_keys = ON;", connection))
        {
            pragmaCommand.ExecuteNonQuery();
        }

        string createTableSql = @"
            CREATE TABLE IF NOT EXISTS Transacoes (
                Id INTEGER PRIMARY KEY,
                TipoTransacao TEXT NOT NULL,
                Valor FLOAT NOT NULL,
                Mes TEXT NOT NULL,
                CarroID INTEGER NOT NULL,
                ClienteID INTEGER NOT NULL,
                FOREIGN KEY (CarroID) REFERENCES Carros (Id),
                FOREIGN KEY (ClienteID) REFERENCES Clientes (Id)
            );
        ";

        using (var command = new SqliteCommand(createTableSql, connection))
        {
            command.ExecuteNonQuery();
        }
        ;
    }

    public void InserirTransacao(Transacao transacao)
    {
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        string sql = "INSERT INTO Transacoes (Id, TipoTransacao, Valor, Mes, CarroID, ClienteID) VALUES (@Id, @TipoTransacao, @Valor, @Mes, @CarroID, @ClienteID)";
        using var command = new SqliteCommand(sql, connection);

        command.Parameters.AddWithValue("@Id", transacao.Id);
        command.Parameters.AddWithValue("@TipoTransacao", transacao.Tipo.ToString());
        command.Parameters.AddWithValue("@Valor", transacao.Valor);
        command.Parameters.AddWithValue("@Mes", transacao.Mes);
        command.Parameters.AddWithValue("@CarroID", transacao.CarroID);
        command.Parameters.AddWithValue("@ClienteID", transacao.ClienteID);

        command.ExecuteNonQuery();
    }

    public List<Transacao> ListarTransacoes(Transacao.TipoTransacao tipo, string mes)
    {
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        string sql = "SELECT * FROM Transacoes WHERE TipoTransacao = @Tipo AND Mes = @Mes;";
        using var command = new SqliteCommand(sql, connection);

        command.Parameters.AddWithValue("@Tipo", tipo.ToString());
        command.Parameters.AddWithValue("@Mes", mes);

        List<Transacao> ListaTransacoes = new List<Transacao>();
        Transacao transacao = new Transacao();

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            int TipoTransacaoValue;
            if (reader.GetString(1) == "Venda")
            {
                TipoTransacaoValue = 1;
            }
            else
            {
                TipoTransacaoValue = 0;
            }

            transacao = new Transacao
            (
                reader.GetInt32(0),
                (Transacao.TipoTransacao)TipoTransacaoValue,
                reader.GetFloat(2),
                reader.GetString(3),
                reader.GetInt32(4),
                reader.GetInt32(5)
            );
            ListaTransacoes.Add(transacao);
        }
        return ListaTransacoes;
    }
    
    public Transacao ListarTransacao(int id)
    {
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        string sql = "SELECT * FROM Transacoes WHERE Id = @Id;";
        using var command = new SqliteCommand(sql, connection);

        command.Parameters.AddWithValue("@Id", id);

        Transacao transacao = new Transacao();

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            int TipoTransacaoValue;
            if (reader.GetString(1) == "Venda")
            {
                TipoTransacaoValue = 1;
            }
            else
            {
                TipoTransacaoValue = 0;
            }

            transacao = new Transacao
            (
                reader.GetInt32(0),
                (Transacao.TipoTransacao)TipoTransacaoValue,
                reader.GetFloat(2),
                reader.GetString(3),
                reader.GetInt32(4),
                reader.GetInt32(5)
            );
        }
        return transacao;
    }

}