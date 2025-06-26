public class Carro : IServiceCarro
{
    private int id;
    private int anoFabricacao;
    private string modelo;
    private int anoModelo;
    private int km;
    // private TipoTransmissao transmissao;
    private float valor;
    private string cor;
    private string chassis;
    // private HashSet<CarroOpcionais> opcionais;

    public Carro(int id, string modelo, int anoFabricacao, int anoModelo, int km, float valor, string cor, string chassis)
    {
        this.id = id;
        this.anoFabricacao = anoFabricacao;
        this.modelo = modelo;
        this.anoModelo = anoModelo;
        this.km = km;
        // this.transmissao = transmissao;
        this.valor = valor;
        this.cor = cor;
        this.chassis = chassis;
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
        List<Carro> lista = new List<Carro>();
        return lista;
    }

    public override string ToString()
    {
        return $"Carro: \nID: {id} \nAno de Fabricacao: {anoFabricacao} \nModelo: {modelo} \nKM: {km} \nValor: {valor} \nCor: {cor} \nChassis: {chassis}";
    }
}