using Microsoft.Data.Sqlite;

public class StorageClienteSqlite
{
    private readonly string _connectionString;

    public StorageClienteSqlite()
    {
        _connectionString = "Data Source=lojaCarros.db;";
        InitializeDatabase();
    }

    public void InitializeDatabase()
    {
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        string createTableSql = @"
            CREATE TABLE IF NOT EXISTS Clientes (
                Id INTEGER PRIMARY KEY,
                Nome TEXT NOT NULL,
                Documento TEXT UNIQUE NOT NULL,
                Logradouro TEXT,
                CasaNumero TEXT,
                Bairro TEXT,
                Complemento TEXT,
                Cidade TEXT,
                Estado TEXT,
                CEP INTEGER
            );
        ";

        using var command = new SqliteCommand(createTableSql, connection);
        command.ExecuteNonQuery();
    }

    public void CadastrarCliente(Cliente cliente)
    {
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        string sql = "INSERT INTO clientes (Id, Nome, Documento, Logradouro, CasaNumero, Bairro, Complemento, Cidade, Estado, Cep) VALUES (@Id, @Nome, @Documento, @Logradouro, @CasaNumero, @Bairro, @Complemento, @Cidade, @Estado, @Cep)";
        using var command = new SqliteCommand(sql, connection);

        command.Parameters.AddWithValue("@Id", cliente.Id);
        command.Parameters.AddWithValue("@Nome", cliente.Nome);
        command.Parameters.AddWithValue("@Documento", cliente.Documento);
        command.Parameters.AddWithValue("@Logradouro", cliente.Logradouro);
        // command.Parameters.AddWithValue("@Contato", cliente.Contato);
        command.Parameters.AddWithValue("@CasaNumero", cliente.CasaNumero);
        command.Parameters.AddWithValue("@Bairro", cliente.Bairro);
        command.Parameters.AddWithValue("@Complemento", cliente.Complemento);
        command.Parameters.AddWithValue("@Cidade", cliente.Cidade);
        command.Parameters.AddWithValue("@Estado", cliente.Estado);
        command.Parameters.AddWithValue("@Cep", cliente.Cep);

        command.ExecuteNonQuery();
    }

    public void ListarClientes()
    {
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        string sql = "SELECT * FROM Clientes;";
        using var command = new SqliteCommand(sql, connection);

        System.Console.WriteLine(command.ExecuteReader());
    }

}