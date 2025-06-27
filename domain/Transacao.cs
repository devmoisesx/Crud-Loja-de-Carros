public class Transacao : IServiceTransacoes
{
    public int Id { get; set; }
    public TipoTransacao Tipo { get; set; }
    public int CarroID { get; set; }
    public int ClienteID { get; set; }
    public float Valor { get; set; }
    public DateTime Data { get; set; }

    public static List<Transacao> TodasTransacoes = new List<Transacao>();

    public enum TipoTransacao
    {
        Compra = 0,
        Venda = 1
    }

    public Transacao(int id, TipoTransacao tipo, int carroID, int clienteID, float valor, DateTime data)
    {
        Id = id;
        Tipo = tipo;
        CarroID = carroID;
        ClienteID = clienteID;
        Valor = valor;
        Data = data;
    }

    public List<Transacao> ListarTransacoes(TipoTransacao tipo, int mes)
    {
        return TodasTransacoes;
    }

    public Transacao ListarTransacao(int id)
    {
        foreach (var transacao in TodasTransacoes)
        {
            if (transacao.Id == id)
            {
                return transacao;
            }
        }
        
        return null;
    }

    public int InsereTransacao(TipoTransacao tipo, int clienteID, int carroID, DateTime data, float valor)
    {
        return 1;
    }
}