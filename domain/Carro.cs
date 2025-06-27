public class Carro : IServiceCarro
{
    public MarcaCarro Marca { get; set; }
    public int Id { get; set; }
    public int AnoFabricacao { get; set; }
    public string Modelo { get; set; }
    public int AnoModelo { get; set; }
    public int Km { get; set; }
    public TipoTransmissao Transmissao { get; set; }
    public float Valor { get; set; }
    public string Cor { get; set; }
    public string Chassis { get; set; }
    // public HashSet<CarroOpcionais> opcionais { get; set; }

    public enum MarcaCarro
    {
        VW,
        GM,
        Ford,
        Toyota,
        Honda
    }
    
    public enum TipoTransmissao
    {
        Manual,
        Automática,
        Automatizado,
        CVT,
        DSG
    }

    // private const CarroOpcionais {
	// 	Blindado,
	// 	Direção Hidraulíca,
	// 	Teto Solar,
	// 	Vidros Elétricos,
	// 	Bancos em Couro,
	// 	Cam Traseira,
	// 	Ar Condicionado,
	// 	Central Multimídia,
	// 	Radio
	// }

    public static List<Carro> TodosCarros = new List<Carro>();

    public Carro() { }

    public Carro(MarcaCarro marca, int id, string modelo, int anoFabricacao, int anoModelo, int km, TipoTransmissao transmissao, float valor, string cor, string chassis)
    {
        Marca = marca;
        Id = id;
        AnoFabricacao = anoFabricacao;
        Modelo = modelo;
        AnoModelo = anoModelo;
        Km = km;
        Transmissao = transmissao;
        Valor = valor;
        Cor = cor;
        Chassis = chassis;
        TodosCarros.Add(this);
    }

    public int CadastrarCarro(Carro carro)
    {
        return 1;
    }

    public Carro ListarCarro(int id)
    {
        foreach (var carro in TodosCarros)
        {
            if (carro.Id == id)
            {
                return carro;
            }
        }
        
        return null;
    }

    public List<Carro> ListarCarros()
    {
        return new List<Carro>(TodosCarros);
    }

    public override string ToString()
    {
        return $"Carro: \nMarca: {Marca} \nAno de Fabricacao: {AnoFabricacao} \nModelo: {Modelo} \nAno do Modelo: {AnoModelo} \nKM: {Km} \nTipo de Transmissão: {Transmissao} \nValor: {Valor} \nCor: {Cor} \nChassis: {Chassis}";
    }
}