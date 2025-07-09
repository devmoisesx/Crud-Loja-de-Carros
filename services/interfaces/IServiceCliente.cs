interface IServiceCliente
{
    void CadastrarCliente(Cliente cliente);
    List<Cliente> ListarClientes();
    Cliente ListarCliente(int id);
}