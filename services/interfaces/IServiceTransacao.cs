public interface IServiceTransacao
{
    List<Transacao> ListarTransacoes(Transacao.TipoTransacao tipo, string mes);
    Transacao ListarTransacao(string id);
    void InserirTransacao(Transacao transacao);
}