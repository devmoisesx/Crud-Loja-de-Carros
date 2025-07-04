// using Microsoft.Data.Sqlite;

// public class SqliteConnectionService
// {
//     private readonly string _connectionString;

//     public SqliteConnectionService()
//     {
//         _connectionString = "Data Source=loja_carros.db";
//     }

//     public SqliteConnection GetConnection()
//     {
//         var connection = new SqliteConnection(_connectionString);
//         connection.Open();
//         return connection;
//     }

//     public void InitializeDatabase()
//     {
//         using var connection = GetConnection();

//         string createTableSql = @"
//             CREATE TABLE IF NOT EXISTS Carros (
//                 Id INTEGER PRIMARY KEY,
//                 Marca TEXT NOT NULL,
//                 Modelo TEXT NOT NULL,
//                 AnoFabricacao INTEGER NOT NULL,
//                 AnoModelo INTEGER NOT NULL,
//                 Km INTEGER NOT NULL,
//                 TipoTransmissao TEXT NOT NULL,
//                 Valor REAL NOT NULL,
//                 Cor TEXT NOT NULL,
//                 Chassis TEXT NOT NULL
//             );

//             CREATE TABLE IF NOT EXISTS Clientes (
//                 Id INTEGER PRIMARY KEY,
//                 Nome TEXT NOT NULL,
//                 Documento TEXT UNIQUE NOT NULL,
//                 Logradouro TEXT,
//                 CasaNumero TEXT,
//                 Bairro TEXT,
//                 Complemento TEXT,
//                 Cidade TEXT,
//                 Estado TEXT,
//                 CEP INTEGER
//             );

//             CREATE TABLE IF NOT EXISTS ClienteContato (
//                 Id INTEGER PRIMARY KEY AUTOINCREMENT,
//                 ClienteId INTEGER NOT NULL,
//                 Tipo TEXT NOT NULL,
//                 Valor TEXT NOT NULL,
//                 FOREIGN KEY (ClienteId) REFERENCES Clientes(Id)
//             );

//             CREATE TABLE IF NOT EXISTS Transacoes (
//                 Id INTEGER PRIMARY KEY,
//                 TipoTransacao INTEGER NOT NULL,
//                 CarroId INTEGER NOT NULL,
//                 ClienteId INTEGER NOT NULL,
//                 Valor REAL NOT NULL,
//                 Data DATETIME NOT NULL,
//                 FOREIGN KEY (CarroId) REFERENCES Carros(Id),
//                 FOREIGN KEY (ClienteId) REFERENCES Clientes(Id)
//             );
//         ";

//         using var command = new SqliteCommand(createTableSql, connection);
//         command.ExecuteNonQuery();
//     }
// }


