interface IServiceCliente
{
    int CadastrarCliente(Cliente cliente);
    List<Cliente> ListarClientes();
    Cliente ListarCliente(int id);
}