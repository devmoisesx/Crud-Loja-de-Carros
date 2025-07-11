public interface IServiceCarro
{
    void CadastrarCarro(Carro carro);
    Carro ListarCarro(string id);
    List<Carro> ListarCarros();
}