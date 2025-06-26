public class Compra
{
    private int id;
    private int carroID;
    private int clienteID;
    private float valor;
    private DateTime data;

    public Compra(int id, int carroID, int clienteID, float valor, DateTime data)
    {
        this.id = id;
        this.carroID = carroID;
        this.clienteID = clienteID;
        this.valor = valor;
        this.data = data;
    }
}