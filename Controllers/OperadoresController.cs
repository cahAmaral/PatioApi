using Microsoft.AspNetCore.Mvc;
using PatioApi.Models;
using PatioApi.Services;

[ApiController]
[Route("api/[controller]")]
public class OperadoresController : ControllerBase
{
    private readonly OperadorService _service;

    public OperadoresController(OperadorService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<Operador>>> Get()
    {
        var operadores = await _service.GetAllAsync();
        return Ok(operadores);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Operador>> Get(int id)
    {
        var operador = await _service.GetByIdAsync(id);
        if (operador == null) return NotFound();
        return Ok(operador);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] Operador operador)
    {
        await _service.AddAsync(operador);
        return CreatedAtAction(nameof(Get), new { id = operador.Id }, operador);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] Operador operador)
    {
        if (id != operador.Id) return BadRequest();
        await _service.UpdateAsync(operador);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _service.DeleteByIdAsync(id);
        return NoContent();
    }

}