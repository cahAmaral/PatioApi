using Microsoft.AspNetCore.Mvc;
using PatioApi.Models;
using PatioApi.Services;

namespace PatioApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MotosController : ControllerBase
    {
        private readonly MotoService _service;

        public MotosController(MotoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Moto>>> Get()
        {
            var motos = await _service.GetAllAsync();
            return Ok(motos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Moto>> Get(int id)
        {
            var moto = await _service.GetByIdAsync(id);
            if (moto == null) return NotFound();
            return Ok(moto);
        }

        [HttpPost]
        public async Task<ActionResult<Moto>> Post([FromBody] Moto moto)
        {
            var novaMoto = await _service.AddAsync(moto);
            return CreatedAtAction(nameof(Get), new { id = novaMoto.Id }, novaMoto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Moto moto)
        {
            if (id != moto.Id) return BadRequest();
            await _service.UpdateAsync(moto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}