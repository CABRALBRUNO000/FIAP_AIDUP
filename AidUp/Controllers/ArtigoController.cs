using AidUp.Models;
using AidUp.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AidUp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtigoController : ControllerBase
    {
        private readonly ArtigoRepository _artigoRepository;

        public ArtigoController(ArtigoRepository artigoRepository)
        {
            _artigoRepository = artigoRepository;
        }

        [HttpGet]
        public async Task<List<ArtigoModel>> Get() =>
            await _artigoRepository.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<ArtigoModel>> Get(string id)
        {
            var artigo = await _artigoRepository.GetAsync(id);

            if (artigo is null)
            {
                return NotFound();
            }

            return Ok(artigo);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ArtigoModel newArtigo)
        {
            await _artigoRepository.CreateAsync(newArtigo);

            return CreatedAtAction(nameof(Get), new { id = newArtigo.IdArtigo }, newArtigo);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, ArtigoModel updatedArtigo)
        {
            var artigo = await _artigoRepository.GetAsync(id);

            if (artigo is null)
            {
                return NotFound();
            }

            updatedArtigo.IdArtigo = artigo.IdArtigo;

            await _artigoRepository.UpdateAsync(id, updatedArtigo);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var artigo = await _artigoRepository.GetAsync(id);

            if (artigo is null)
            {
                return NotFound();
            }

            await _artigoRepository.RemoveAsync(id);

            return NoContent();
        }
    }
}
