public interface IServiceCarro
{
    void CadastrarCarro(Carro carro);
    Carro ListarCarro(int id);
    List<Carro> ListarCarros();
}