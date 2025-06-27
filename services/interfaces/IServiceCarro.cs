interface IServiceCarro
{
    int CadastrarCarro(Carro carro);
    Carro ListarCarro(int id);
    List<Carro> ListarCarros();
}