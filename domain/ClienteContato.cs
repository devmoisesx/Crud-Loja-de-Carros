public class ClienteContato
{
    public TipoContato Tipo { get; set; }
    public string Valor { get; set; }

    public enum TipoContato
    {
        Telefone,
        Email,
        Sinal_De_Fumaca,
        Aviso_No_Bar,
        Recado_Na_Igreja
    }

    public ClienteContato(TipoContato tipo, string valor)
    {
        Tipo = tipo;
        Valor = valor;
    }
}