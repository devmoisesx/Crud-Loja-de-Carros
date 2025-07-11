using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    private readonly IServiceCliente _serviceCliente;

    public ClientesController(IServiceCliente serviceCliente)
    {
        _serviceCliente = serviceCliente;
    }

    // Get api/clientes
    [HttpGet]
    public ActionResult<List<Cliente>> GetClientes()
    {
        try
        {
            var clientes = _serviceCliente.ListarClientes();
            return Ok(clientes);
        }
        catch (System.Exception e)
        {
            return StatusCode(500, $"Erro interno: {e.Message}");
        }
    }

    // Get api/cliente?id=ID
    [HttpGet("{id}")]
    public ActionResult<Cliente> GetCliente(string id)
    {
        try
        {
            var cliente = _serviceCliente.ListarCliente(id);
            return Ok(cliente);
        }
        catch (System.Exception e)
        {
            return StatusCode(500, $"Erro interno: {e.Message}");
        }
    }

    [HttpPost]
    public ActionResult<Cliente> PostCliente(Cliente cliente)
    {
        try
        {
            _serviceCliente.CadastrarCliente(cliente);
            return CreatedAtAction(nameof(GetClientes), cliente);
        }
        catch (System.Exception e)
        {
            return BadRequest($"Erro ao criar transacao: {e.Message}");
        }
    }
}