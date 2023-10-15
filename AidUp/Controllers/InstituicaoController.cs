using AidUp.Models;
using AidUp.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AidUp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstituicaoController : ControllerBase
    {
        private readonly InstituicaoRepository _instituicaoRepository;

        public InstituicaoController(InstituicaoRepository instituicaoRepository)
        {
            _instituicaoRepository = instituicaoRepository;
        }

        [HttpGet]
        public async Task<List<InstituicaoModel>> Get() =>
            await _instituicaoRepository.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<InstituicaoModel>> Get(string id)
        {
            var instituicao = await _instituicaoRepository.GetAsync(id);

            if (instituicao is null)
            {
                return NotFound();
            }

            return Ok(instituicao);
        }

        [HttpPost]
        public async Task<IActionResult> Post(InstituicaoModel newInstituicao)
        {
            await _instituicaoRepository.CreateAsync(newInstituicao);

            return CreatedAtAction(nameof(Get), new { id = newInstituicao.IdInstituicao }, newInstituicao);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, InstituicaoModel updatedInstituicao)
        {
            var instituicao = await _instituicaoRepository.GetAsync(id);

            if (instituicao is null)
            {
                return NotFound();
            }

            updatedInstituicao.IdInstituicao = instituicao.IdInstituicao;

            await _instituicaoRepository.UpdateAsync(id, updatedInstituicao);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var instituicao = await _instituicaoRepository.GetAsync(id);

            if (instituicao is null)
            {
                return NotFound();
            }

            await _instituicaoRepository.RemoveAsync(id);

            return NoContent();
        }
    }
}
