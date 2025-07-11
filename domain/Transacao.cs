public class Transacao
{
    public string Id { get; set; }
    public TipoTransacao Tipo { get; set; }
    public float Valor { get; set; }
    public string? Mes { get; set; }
    public string? CarroID { get; set; }
    public string? ClienteID { get; set; }

    public enum TipoTransacao
    {
        Compra,
        Venda
    }

    public Transacao()
    {
        Id = Ulid.NewUlid().ToString();
    }

    public Transacao(TipoTransacao tipo, float valor, string mes, string carroID, string clienteID)
    {
        Id = Ulid.NewUlid().ToString();
        Tipo = tipo;
        Valor = valor;
        Mes = mes;
        CarroID = carroID;
        ClienteID = clienteID;
    }

    public Transacao(string id, TipoTransacao tipo, float valor, string mes, string carroID, string clienteID)
    {
        Id = id;
        Tipo = tipo;
        Valor = valor;
        Mes = mes;
        CarroID = carroID;
        ClienteID = clienteID;
    }

    public override string ToString()
    {
        return $"Transacao: \nId: {Id} \nTipo: {Tipo} \nValor: {Valor} \nMes: {Mes} \nCarro ID: {CarroID} \nCliente ID: {ClienteID}";
    }
}