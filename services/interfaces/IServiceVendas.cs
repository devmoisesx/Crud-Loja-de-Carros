interface IServiceVendas
{
    List<Transacao> ListarTransacoes(TipoTransacao tipo, int mes);
    Transacao ListaTransacao(int id);
    int InsereTransacao(TipoTransacao tipo, int clienteID, int carroID, DateTime data, float valor);
}