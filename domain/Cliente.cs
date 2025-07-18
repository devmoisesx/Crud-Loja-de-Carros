public class Cliente
{
    public string Id { get; set; }
    public string? Nome { get; set; }
    public string? Documento { get; set; }
    // public List<ClienteContato> Contato { get; set; }
    public string? Logradouro { get; set; }
    public string? CasaNumero { get; set; }
    public string? Bairro { get; set; }
    public string? Complemento { get; set; }
    public string? Cidade { get; set; }
    public string? Estado { get; set; }
    public int Cep { get; set; }

    public Cliente()
    {
        Id = Ulid.NewUlid().ToString();
    }

    public Cliente(string id, string nome, string documento, string logradouro, string casaNumero, string bairro, string complemento, string cidade, string estado, int cep)
    {
        Id = id;
        Nome = nome;
        Documento = documento;
        // Contato = contato;
        Logradouro = logradouro;
        CasaNumero = casaNumero;
        Bairro = bairro;
        Complemento = complemento;
        Cidade = cidade;
        Estado = estado;
        Cep = cep;
    }

      public Cliente(string nome, string documento, string logradouro, string casaNumero, string bairro, string complemento, string cidade, string estado, int cep)
    {
        Id = Ulid.NewUlid().ToString();
        Nome = nome;
        Documento = documento;
        // Contato = contato;
        Logradouro = logradouro;
        CasaNumero = casaNumero;
        Bairro = bairro;
        Complemento = complemento;
        Cidade = cidade;
        Estado = estado;
        Cep = cep;
    }

    public override string ToString()
    {
        return $"Cliente: \nID: {Id} \nNome: {Nome} \nDocumento: {Documento} \nLogradouro: {Logradouro} \nNumero da Casa: {CasaNumero} \nBairro: {Bairro} \nComplemento: {Complemento} \nCidade: {Cidade} \nEstado: {Estado} \nCep: {Cep}";
    }
}