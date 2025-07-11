public class Transacao
{
    public int Id { get; set; }
    public TipoTransacao Tipo { get; set; }
    public float Valor { get; set; }
    public string Mes { get; set; }
    public int CarroID { get; set; }
    public int ClienteID { get; set; }

    public enum TipoTransacao
    {
        Compra,
        Venda
    }

    public Transacao() { }

    public Transacao(int id, TipoTransacao tipo, float valor, string mes, int carroID, int clienteID)
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