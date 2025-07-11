public class ServiceTransacao : IServiceTransacao
{
    private readonly StorageTransacaoSqlite _storage = new StorageTransacaoSqlite();

    public ServiceTransacao(StorageTransacaoSqlite storage)
    {
        _storage = storage;
    }

    public List<Transacao> ListarTransacoes(Transacao.TipoTransacao tipo, string mes)
    {
        return _storage.ListarTransacoes(tipo, mes);
    }

    public Transacao ListarTransacao(string id)
    {
        return _storage.ListarTransacao(id);
    }

    public void InserirTransacao(Transacao transacao) {
        _storage.InserirTransacao(transacao);
    }
}