// ServiceCarro servicoCarro = new ServiceCarro();

// Carro carro1 = new(1, (Carro.MarcaCarro)1, "Banana", 1990, 2025, 50000, (Carro.TipoTransmissao)1, 157.912F, "preto", "1SFD9821DA09");

// servicoCarro.CadastrarCarro(carro1);

// foreach (var carro in servicoCarro.ListarCarros())
// {
//     System.Console.WriteLine(carro);
//    System.Console.WriteLine();
// }

// System.Console.WriteLine(storageCarro.ListarCarro(3));

// ----------------------------------------------------------------------- 

// ServiceCliente servicoCliente = new ServiceCliente();

// Cliente cliente1 = new(1, "Túlio", "823765982", "Alfredo", "91", "Coxinha", "", "São Paulo", "São Paulo", 0241412);

// Cliente cliente2 = new(2, "Ana", "129849812", "Alfredo", "91", "Coxinha", "", "São Paulo", "São Paulo", 0241312);

// servicoCliente.CadastrarCliente(cliente1);
// servicoCliente.CadastrarCliente(cliente2);


// foreach (var cliente in servicoCliente.ListarClientes())
// {
//     System.Console.WriteLine(cliente);
//     System.Console.WriteLine();
// }

// ----------------------------------------------------------------------- 

ServiceTransacao serviceTransacao = new ServiceTransacao();

// Transacao transacao1 = new Transacao(6, (Transacao.TipoTransacao)1, 25.000f, "07-2025", 2, 1);

// serviceTransacao.InserirTransacao(transacao1);

// string MesTransacao = "07-2025";

// foreach (var transacao in serviceTransacao.ListarTransacoes((Transacao.TipoTransacao)1, MesTransacao))
// {
//     System.Console.WriteLine(transacao);
//     System.Console.WriteLine();
// }

System.Console.WriteLine(serviceTransacao.ListarTransacao(5));