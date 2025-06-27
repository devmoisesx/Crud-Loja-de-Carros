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
        VW = 0,
        GM = 1,
        Ford = 2,
        Toyota = 3,
        Honda = 4
    }
    
    public enum TipoTransmissao
    {
        Manual = 0,
        Automática = 1,
        Automatizado = 2,
        CVT = 3,
        DSG = 4
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
        this.Marca = marca;
        this.Id = id;
        this.AnoFabricacao = anoFabricacao;
        this.Modelo = modelo;
        this.AnoModelo = anoModelo;
        this.Km = km;
        this.Transmissao = transmissao;
        this.Valor = valor;
        this.Cor = cor;
        this.Chassis = chassis;
        TodosCarros.Add(this);
    }

    public int CadastrarCarro(Carro carro)
    {
        return 1;
    }

    // public Carro ListarCarro(int id) {
    //     Carro carro = Carro.id;
    //     return Carro;
    // }

    public List<Carro> ListarCarros()
    {
        return TodosCarros;
    }

    public override string ToString()
    {
        return $"Carro: \nMarca: {Marca} \nAno de Fabricacao: {AnoFabricacao} \nModelo: {Modelo} \nAno do Modelo: {AnoModelo} \nKM: {Km} \nTipo de Transmissão: {Transmissao} \nValor: {Valor} \nCor: {Cor} \nChassis: {Chassis}";
    }
}