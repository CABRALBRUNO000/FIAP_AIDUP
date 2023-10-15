using AidUp.Models;
using AidUp.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AidUp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {

        private readonly EventoRepository _eventoRepository;

        public EventoController(EventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }

        [HttpGet]
        public async Task<List<EventoModel>> Get() =>
            await _eventoRepository.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<EventoModel>> Get(string id)
        {
            var evento = await _eventoRepository.GetAsync(id);

            if (evento is null)
            {
                return NotFound();
            }

            return Ok(evento);
        }

        [HttpPost]
        public async Task<IActionResult> Post(EventoModel newEvento)
        {
            await _eventoRepository.CreateAsync(newEvento);

            return CreatedAtAction(nameof(Get), new { id = newEvento.IdEvento }, newEvento);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, EventoModel updatedEvento)
        {
            var evento = await _eventoRepository.GetAsync(id);

            if (evento is null)
            {
                return NotFound();
            }

            updatedEvento.IdEvento = evento.IdEvento;

            await _eventoRepository.UpdateAsync(id, updatedEvento);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var evento = await _eventoRepository.GetAsync(id);

            if (evento is null)
            {
                return NotFound();
            }

            await _eventoRepository.RemoveAsync(id);

            return NoContent();
        }

    }
}
