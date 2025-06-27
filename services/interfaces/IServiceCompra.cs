interface IServiceCompra
{
    List<Compra> ListarCompras(int mes);
    Compra ListarCompra(int id);
    int InsereCompra(int clienteID, int carroID, DateTime data, float valor);
}