public class ServiceCarro : IServiceCarro
{
    private readonly StorageCarroSqlite _storage;

    public ServiceCarro(StorageCarroSqlite storage)
    {
        _storage = storage;
    }

    public void CadastrarCarro(Carro carro)
    {
        _storage.CadastrarCarro(carro);
    }

    public Carro ListarCarro(string id)
    {
        return _storage.ListarCarro(id);
    }

    public List<Carro> ListarCarros()
    {
        return _storage.ListarCarros();
    }
}