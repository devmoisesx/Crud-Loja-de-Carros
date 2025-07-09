public class ServiceCarro : IServiceCarro
{
    private readonly StorageCarroSqlite _storage = new StorageCarroSqlite();

    public void CadastrarCarro(Carro carro)
    {
        _storage.CadastrarCarro(carro);
    }

    public Carro ListarCarro(int id)
    {
        return _storage.ListarCarro(id);
    }

    public List<Carro> ListarCarros()
    {
        return _storage.ListarCarros();
    }
}