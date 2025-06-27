// Carro carro1 = new((Carro.MarcaCarro)1, 123, "Banana", 1990, 2025, 50000, (Carro.TipoTransmissao)1, 157.912F, "preto", "1SFD9821DA09");
// Carro carro2 = new((Carro.MarcaCarro)1, 1765, "Asas", 1990, 2025, 50000, (Carro.TipoTransmissao)1, 157.912F, "branco", "1SFD9821DA09");

// Console.WriteLine(carro1);

// System.Console.WriteLine("------------------");

// Carro carro = new Carro();
// System.Console.WriteLine(carro.ListarCarros());

// System.Console.WriteLine("------------------");

// System.Console.WriteLine(carro.ListarCarro(1765));

Cliente cliente1 = new Cliente(1, "Túlio", "823765982", "Alfredo", "91", "Coxinha", "", "São Paulo", "São Paulo", 02414 - 12);
Cliente cliente2 = new Cliente(2, "Ana", "823765982", "Alfredo", "91", "Coxinha", "", "São Paulo", "São Paulo", 02414 - 12);

System.Console.WriteLine(cliente1);

System.Console.WriteLine("------------------");

Cliente cliente = new Cliente();
System.Console.WriteLine(cliente.ListarCliente(2));