public class Transacao
{
    private int id;
    private TipoTransacao tipo;
    private int carroID;
    private int clienteID;
    private float valor;
    private DateTime data;

    public enum TipoTransacao
    {
        Compra = 0,
        Venda = 1
    }

    public Transacao(int id, TipoTransacao tipo, int carroID, int clienteID, float valor, DateTime data)
    {
        this.id = id;
        this.tipo = tipo;
        this.carroID = carroID;
        this.clienteID = clienteID;
        this.valor = valor;
        this.data = data;
    }
}