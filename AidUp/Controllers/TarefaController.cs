using AidUp.Models;
using AidUp.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AidUp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {

        private readonly TarefaRepository _tarefaRepository;

        public TarefaController(TarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        [HttpGet]
        public async Task<List<TarefaModel>> Get() =>
            await _tarefaRepository.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<TarefaModel>> Get(string id)
        {
            var tarefa = await _tarefaRepository.GetAsync(id);

            if (tarefa is null)
            {
                return NotFound();
            }

            return Ok(tarefa);
        }

        [HttpPost]
        public async Task<IActionResult> Post(TarefaModel newTarefa)
        {
            await _tarefaRepository.CreateAsync(newTarefa);

            return CreatedAtAction(nameof(Get), new { id = newTarefa.IdTarefa }, newTarefa);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, TarefaModel updatedTarefa)
        {
            var tarefa = await _tarefaRepository.GetAsync(id);

            if (tarefa is null)
            {
                return NotFound();
            }

            updatedTarefa.IdTarefa = tarefa.IdTarefa;

            await _tarefaRepository.UpdateAsync(id, updatedTarefa);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var tarefa = await _tarefaRepository.GetAsync(id);

            if (tarefa is null)
            {
                return NotFound();
            }

            await _tarefaRepository.RemoveAsync(id);

            return NoContent();
        }

    }
}
