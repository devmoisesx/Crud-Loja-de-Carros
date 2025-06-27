public class Compra : IServiceCompra
{
    public int Id { get; set; }
    public int CarroID { get; set; }
    public int ClienteID { get; set; }
    public float Valor { get; set; }
    public DateTime Data { get; set; }
    public static List<Compra> TodasCompras = new List<Compra>();

    public Compra(int id, int carroID, int clienteID, float valor, DateTime data)
    {
        Id = id;
        CarroID = carroID;
        ClienteID = clienteID;
        Valor = valor;
        Data = data;
    }

    public List<Compra> ListarCompras(int mes)
    {
        return TodasCompras;
    }

    public Compra ListarCompra(int id)
    {
        foreach (var compra in TodasCompras)
        {
            if (compra.Id == id)
            {
                return compra;
            }
        }
        
        return null;
    }

    public int InsereCompra(int clienteID, int carroID, DateTime data, float valor)
    {
        return 1;
    }
}