var storageCarro = new StorageCarroSqlite();

var storageCliente = new StorageClienteSqlite();

Carro carro1 = new((Carro.MarcaCarro)1, "Banana", 1990, 2025, 50000, (Carro.TipoTransmissao)1, 157.912F, "preto", "1SFD9821DA09");

// storageCarro.CadastrarCarro(carro1);

Cliente cliente1 = new(1, "Túlio", "823765982", "Alfredo", "91", "Coxinha", "", "São Paulo", "São Paulo", 0241412);

Cliente cliente2 = new(2, "Ana", "129849812", "Alfredo", "91", "Coxinha", "", "São Paulo", "São Paulo", 0241312);

// storageCliente.CadastrarCliente(cliente1);
// storageCliente.CadastrarCliente(cliente2);

storageCliente.ListarClientes();