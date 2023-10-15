using AidUp.Models;
using AidUp.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AidUp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LembreteController : ControllerBase
    {

        private readonly LembreteRepository _lembreteRepository;

        public LembreteController(LembreteRepository lembreteRepository)
        {
            _lembreteRepository = lembreteRepository;
        }

        [HttpGet]
        public async Task<List<LembreteModel>> Get() =>
            await _lembreteRepository.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<LembreteModel>> Get(string id)
        {
            var lembrete = await _lembreteRepository.GetAsync(id);

            if (lembrete is null)
            {
                return NotFound();
            }

            return Ok(lembrete);
        }

        [HttpPost]
        public async Task<IActionResult> Post(LembreteModel newLembrete)
        {
            await _lembreteRepository.CreateAsync(newLembrete);

            return CreatedAtAction(nameof(Get), new { id = newLembrete.IdLembrete }, newLembrete);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, LembreteModel updateLembrete)
        {
            var lembrete = await _lembreteRepository.GetAsync(id);

            if (lembrete is null)
            {
                return NotFound();
            }

            updateLembrete.IdLembrete = lembrete.IdLembrete;

            await _lembreteRepository.UpdateAsync(id, updateLembrete);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var lembrete = await _lembreteRepository.GetAsync(id);

            if (lembrete is null)
            {
                return NotFound();
            }

            await _lembreteRepository.RemoveAsync(id);

            return NoContent();
        }

    }
}
