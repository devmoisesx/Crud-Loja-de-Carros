using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TransacoesController : ControllerBase
{
    private readonly ServiceTransacao _serviceTransacao;

    public TransacoesController(ServiceTransacao serviceTransacao)
    {
        _serviceTransacao = serviceTransacao;
    }

    // Get api/transacoes?tipo=TIPO&mes=MES
    [HttpGet]
    public ActionResult<List<Transacao>> GetTransacoes(
        [FromQuery] Transacao.TipoTransacao tipo,
        [FromQuery] string mes
    )
    {
        try
        {
            var transacoes = _serviceTransacao.ListarTransacoes(tipo, mes);
            return Ok(transacoes);
        }
        catch (System.Exception e)
        {

            return StatusCode(500, $"Erro interno: {e.Message}");
        }
    }

    // Get api/transacao?id=ID
    [HttpGet("{id}")]
    public ActionResult<Transacao> GetTransacao(int id)
    {
        try
        {
            var transacao = _serviceTransacao.ListarTransacao(id);
            return Ok(transacao);
        }
        catch (System.Exception e)
        {

            return StatusCode(500, $"Erro interno: {e.Message}");
        }
    }

    [HttpPost]
    public ActionResult<Transacao> PostTransacao(Transacao transacao)
    {
        try
        {
            _serviceTransacao.InserirTransacao(transacao);
            return CreatedAtAction(nameof(GetTransacoes), transacao);
        }
        catch (System.Exception e)
        {
            return BadRequest($"Erro ao criar transacao: {e.Message}");
        }
    }
}