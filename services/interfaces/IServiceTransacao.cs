public interface IServiceTransacao
{
    List<Transacao> ListarTransacoes(Transacao.TipoTransacao tipo, string mes);
    Transacao ListarTransacao(int id);
    void InserirTransacao(Transacao transacao);
}