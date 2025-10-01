using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class MovimentacoesController : ControllerBase
{
    private readonly MovimentacaoService _service;

    public MovimentacoesController(MovimentacaoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<Movimentacao>>> Get()
    {
        var movs = await _service.GetAllAsync();
        return Ok(movs);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Movimentacao>> Get(int id)
    {
        var mov = await _service.GetByIdAsync(id);
        if (mov == null) return NotFound();
        return Ok(mov);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] Movimentacao movimentacao)
    {
        await _service.AddAsync(movimentacao);
        return CreatedAtAction(nameof(Get), new { id = movimentacao.Id }, movimentacao);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] Movimentacao movimentacao)
    {
        if (id != movimentacao.Id) return BadRequest();
        await _service.UpdateAsync(movimentacao);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}