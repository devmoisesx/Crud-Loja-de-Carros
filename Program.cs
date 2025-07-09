ServiceCarro servicoCarro = new ServiceCarro();

// Carro carro1 = new(1, (Carro.MarcaCarro)1, "Banana", 1990, 2025, 50000, (Carro.TipoTransmissao)1, 157.912F, "preto", "1SFD9821DA09");

// servicoCarro.CadastrarCarro(carro1);

foreach (var carro in servicoCarro.ListarCarros())
{
    System.Console.WriteLine(carro);
   System.Console.WriteLine();
}

// System.Console.WriteLine(storageCarro.ListarCarro(3));

// ----------------------------------------------------------------------- 

// var storageCliente = new StorageClienteSqlite();

// Cliente cliente1 = new(1, "Túlio", "823765982", "Alfredo", "91", "Coxinha", "", "São Paulo", "São Paulo", 0241412);

// Cliente cliente2 = new(2, "Ana", "129849812", "Alfredo", "91", "Coxinha", "", "São Paulo", "São Paulo", 0241312);

// storageCliente.CadastrarCliente(cliente1);
// storageCliente.CadastrarCliente(cliente2);


// System.Console.WriteLine(.ToString());

// foreach (var cliente in storageCliente.ListarClientes())
// {
//     System.Console.WriteLine(cliente);
//    System.Console.WriteLine();
// }

// ----------------------------------------------------------------------- 

// StorageTransacaoSqlite storageTransacao = new StorageTransacaoSqlite();

// // Transacao transacao1 = new Transacao(1, (Transacao.TipoTransacao)1, 1, 1, 25.000f, "08-07-2025");
// Transacao transacao2 = new Transacao(2, (Transacao.TipoTransacao)0, 4, 2, 25.000f, "08-07-2025");

// storageTransacao.InserirTransacao(transacao2);