using AidUp.Models;
using AidUp.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AidUp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComunicadoController : ControllerBase
    {

        private readonly ComunicadoRepository _comunicadoRepository;

        public ComunicadoController(ComunicadoRepository comunicadoRepository)
        {
            _comunicadoRepository = comunicadoRepository;
        }

        [HttpGet]
        public async Task<List<ComunicadoModel>> Get() =>
            await _comunicadoRepository.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<ComunicadoModel>> Get(string id)
        {
            var comunicado = await _comunicadoRepository.GetAsync(id);

            if (comunicado is null)
            {
                return NotFound();
            }

            return Ok(comunicado);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ComunicadoModel newComunicado)
        {
            await _comunicadoRepository.CreateAsync(newComunicado);

            return CreatedAtAction(nameof(Get), new { id = newComunicado.IdComunicado }, newComunicado);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, ComunicadoModel updatedComunicado)
        {
            var instituicao = await _comunicadoRepository.GetAsync(id);

            if (instituicao is null)
            {
                return NotFound();
            }

            updatedComunicado.IdComunicado = instituicao.IdComunicado;

            await _comunicadoRepository.UpdateAsync(id, updatedComunicado);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var instituicao = await _comunicadoRepository.GetAsync(id);

            if (instituicao is null)
            {
                return NotFound();
            }

            await _comunicadoRepository.RemoveAsync(id);

            return NoContent();
        }

    }
}
