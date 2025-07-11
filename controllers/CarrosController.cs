using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CarrosController : ControllerBase
{
    private readonly IServiceCarro _serviceCarro;

    public CarrosController(IServiceCarro serviceCarro)
    {
        _serviceCarro = serviceCarro;
    }

    // Get api/carros
    [HttpGet]
    public ActionResult<List<Carro>> GetCarros()
    {
        try
        {
            List<Carro> carros = _serviceCarro.ListarCarros();
            return Ok(carros);
        }
        catch (System.Exception e)
        {
            return StatusCode(500, $"Erro interno: {e.Message}");
        }
    }

    [HttpGet("{id}")]
    public ActionResult<Carro> GetCarro(int id)
    {
        try
        {
            var carro = _serviceCarro.ListarCarro(id);
            if (carro == null)
            {
                return NotFound($"Carro com ID {id} não encontrado");
            }
            return Ok(carro);
        }
        catch (System.Exception e)
        {
            return StatusCode(500, $"Erro interno: {e.Message}");
        }
    }

    [HttpPost]
    public ActionResult<Carro> PostCarro(Carro carro)
    {
        try
        {
            _serviceCarro.CadastrarCarro(carro);
            return CreatedAtAction(nameof(GetCarro), new { id = carro.Id }, carro);
        }
        catch (System.Exception e)
        {
            return BadRequest($"Erro ao cadastrar carro: {e.Message}");
        }
    }
}