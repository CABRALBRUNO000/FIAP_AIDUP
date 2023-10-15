using AidUp.Models;
using AidUp.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AidUp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnqueteController : ControllerBase
    {

        private readonly EnqueteRepository _enqueteRepository;

        public EnqueteController(EnqueteRepository enqueteRepository)
        {
            _enqueteRepository = enqueteRepository;
        }

        [HttpGet]
        public async Task<List<EnqueteModel>> Get() =>
            await _enqueteRepository.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<EnqueteModel>> Get(string id)
        {
            var enquete = await _enqueteRepository.GetAsync(id);

            if (enquete is null)
            {
                return NotFound();
            }

            return Ok(enquete);
        }

        [HttpPost]
        public async Task<IActionResult> Post(EnqueteModel newEnquete)
        {
            await _enqueteRepository.CreateAsync(newEnquete);

            return CreatedAtAction(nameof(Get), new { id = newEnquete.IdEnquete }, newEnquete);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, EnqueteModel updatedEnquete)
        {
            var enquete = await _enqueteRepository.GetAsync(id);

            if (enquete is null)
            {
                return NotFound();
            }

            updatedEnquete.IdEnquete = enquete.IdEnquete;

            await _enqueteRepository.UpdateAsync(id, updatedEnquete);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var enquete = await _enqueteRepository.GetAsync(id);

            if (enquete is null)
            {
                return NotFound();
            }

            await _enqueteRepository.RemoveAsync(id);

            return NoContent();
        }

    }
}
