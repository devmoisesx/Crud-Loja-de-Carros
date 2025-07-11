public interface IServiceCliente
{
    void CadastrarCliente(Cliente cliente);
    List<Cliente> ListarClientes();
    Cliente ListarCliente(string id);
}