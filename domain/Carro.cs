public class Carro
{

    public string Id { get; set; }
    public MarcaCarro Marca { get; set; }
    public int AnoFabricacao { get; set; }
    public string? Modelo { get; set; }
    public int AnoModelo { get; set; }
    public int Km { get; set; }
    public TipoTransmissao Transmissao { get; set; }
    public float Valor { get; set; }
    public string? Cor { get; set; }
    public string? Chassis { get; set; }
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
    };

    public Carro()
    {
        Id = Ulid.NewUlid().ToString();
    }

    public Carro(MarcaCarro marca, string modelo, int anoFabricacao, int anoModelo, 
                 int km, TipoTransmissao transmissao, float valor, string cor, string chassis)
    {
        Id = Ulid.NewUlid().ToString(); 
        Marca = marca;
        AnoFabricacao = anoFabricacao;
        Modelo = modelo;
        AnoModelo = anoModelo;
        Km = km;
        Transmissao = transmissao;
        Valor = valor;
        Cor = cor;
        Chassis = chassis;
    }

    public Carro(string id, MarcaCarro marca, string modelo, int anoFabricacao, 
                 int anoModelo, int km, TipoTransmissao transmissao, float valor, 
                 string cor, string chassis)
    {
        Id = id; 
        Marca = marca;
        AnoFabricacao = anoFabricacao;
        Modelo = modelo;
        AnoModelo = anoModelo;
        Km = km;
        Transmissao = transmissao;
        Valor = valor;
        Cor = cor;
        Chassis = chassis;
    }

    public override string ToString()
    {
        return $"Carro: \nId: {Id} \nMarca: {Marca} \nAno de Fabricacao: {AnoFabricacao} \nModelo: {Modelo} \nAno do Modelo: {AnoModelo} \nKM: {Km} \nTipo de Transmissão: {Transmissao} \nValor: {Valor} \nCor: {Cor} \nChassis: {Chassis}";
    }
}