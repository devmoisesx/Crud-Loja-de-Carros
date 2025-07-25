using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
                Id TEXT PRIMARY KEY NOT NULL UNIQUE,
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

        command.Parameters.AddWithValue("@Id", transacao.Id.ToString());
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
        Transacao transacao;

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            int TipoTransacaoValue;
            if (reader.GetString(1).Equals("Venda"))
            {
                TipoTransacaoValue = 1;
            }
            else
            {
                TipoTransacaoValue = 0;
            }

            transacao = new Transacao
            (
                reader.GetString(0),
                (Transacao.TipoTransacao)TipoTransacaoValue,
                reader.GetFloat(2),
                reader.GetString(3),
                reader.GetString(4),
                reader.GetString(5)
            );
            ListaTransacoes.Add(transacao);
        }
        return ListaTransacoes;
    }
    
    public Transacao ListarTransacao(string id)
    {
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        string sql = "SELECT * FROM Transacoes WHERE Id = @Id;";
        using var command = new SqliteCommand(sql, connection);
        command.Parameters.AddWithValue("@Id", id);

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

            return new Transacao
            (
                reader.GetString(0),
                (Transacao.TipoTransacao)TipoTransacaoValue,
                reader.GetFloat(2),
                reader.GetString(3),
                reader.GetString(4),
                reader.GetString(5)
            );
        }
        throw new KeyNotFoundException($"Transacao com ID {id} não encontrada.");
    }

}