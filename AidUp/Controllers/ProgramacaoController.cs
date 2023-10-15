using AidUp.Models;
using AidUp.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AidUp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramacaoController : ControllerBase
    {

        private readonly ProgramacaoRepository _programacaoRepository;

        public ProgramacaoController(ProgramacaoRepository programacaoRepository)
        {
            _programacaoRepository = programacaoRepository;
        }

        [HttpGet]
        public async Task<List<ProgramacaoModel>> Get() =>
            await _programacaoRepository.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<ProgramacaoModel>> Get(string id)
        {
            var programacao = await _programacaoRepository.GetAsync(id);

            if (programacao is null)
            {
                return NotFound();
            }

            return Ok(programacao);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProgramacaoModel newProgramacao)
        {
            await _programacaoRepository.CreateAsync(newProgramacao);

            return CreatedAtAction(nameof(Get), new { id = newProgramacao.idProgramacao }, newProgramacao);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, ProgramacaoModel updatedProgramacao)
        {
            var programacao = await _programacaoRepository.GetAsync(id);

            if (programacao is null)
            {
                return NotFound();
            }

            updatedProgramacao.idProgramacao = programacao.idProgramacao;

            await _programacaoRepository.UpdateAsync(id, updatedProgramacao);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var programacao = await _programacaoRepository.GetAsync(id);

            if (programacao is null)
            {
                return NotFound();
            }

            await _programacaoRepository.RemoveAsync(id);

            return NoContent();
        }

    }
}
