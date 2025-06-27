interface IServiceTransacoes
{
    List<Transacao> ListarTransacoes(Transacao.TipoTransacao tipo, int mes);
    Transacao ListarTransacao(int id);
    int InsereTransacao(Transacao.TipoTransacao tipo, int clienteID, int carroID, DateTime data, float valor);
}