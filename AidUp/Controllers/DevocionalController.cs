using AidUp.Models;
using AidUp.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AidUp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevocionalController : ControllerBase
    {

        private readonly DevocionalRepository _devocionalRepository;

        public DevocionalController(DevocionalRepository devocionalRepository)
        {
            _devocionalRepository = devocionalRepository;
        }

        [HttpGet]
        public async Task<List<DevocionalModel>> Get() =>
            await _devocionalRepository.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<DevocionalModel>> Get(string id)
        {
            var devocional = await _devocionalRepository.GetAsync(id);

            if (devocional is null)
            {
                return NotFound();
            }

            return Ok(devocional);
        }

        [HttpPost]
        public async Task<IActionResult> Post(DevocionalModel newDevocional)
        {
            await _devocionalRepository.CreateAsync(newDevocional);

            return CreatedAtAction(nameof(Get), new { id = newDevocional.IdDevocional }, newDevocional);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, DevocionalModel updatedDevocional)
        {
            var devocional = await _devocionalRepository.GetAsync(id);

            if (devocional is null)
            {
                return NotFound();
            }

            updatedDevocional.IdDevocional = devocional.IdDevocional;

            await _devocionalRepository.UpdateAsync(id, updatedDevocional);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var devocional = await _devocionalRepository.GetAsync(id);

            if (devocional is null)
            {
                return NotFound();
            }

            await _devocionalRepository.RemoveAsync(id);

            return NoContent();
        }

    }
}
