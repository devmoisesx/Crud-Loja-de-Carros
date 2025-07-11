public class ServiceCliente : IServiceCliente
{
    private readonly StorageClienteSqlite _storage;

    public ServiceCliente(StorageClienteSqlite storage)
    {
        _storage = storage;
    }

    public void CadastrarCliente(Cliente cliente)
    {
        _storage.CadastrarCliente(cliente);
    }

    public Cliente ListarCliente(string id)
    {
        return _storage.ListarCliente(id);
    }

    public List<Cliente> ListarClientes()
    {
        return _storage.ListarClientes();
    }
}