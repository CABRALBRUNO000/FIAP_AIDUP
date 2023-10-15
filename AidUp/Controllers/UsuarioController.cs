using AidUp.Models;
using AidUp.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AidUp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioRepository _usuarioRepository;

        public UsuarioController(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public async Task<List<UsuarioModel>> Get() =>
            await _usuarioRepository.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<UsuarioModel>> Get(string id)
        {
            var usuario = await _usuarioRepository.GetAsync(id);

            if (usuario is null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Post(UsuarioModel newUsuario)
        {
            await _usuarioRepository.CreateAsync(newUsuario);

            return CreatedAtAction(nameof(Get), new { id = newUsuario.IdUsuario }, newUsuario);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, UsuarioModel updatedUsuario)
        {
            var usuario = await _usuarioRepository.GetAsync(id);

            if (usuario is null)
            {
                return NotFound();
            }

            updatedUsuario.IdUsuario = usuario.IdUsuario;

            await _usuarioRepository.UpdateAsync(id, updatedUsuario);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var usuario = await _usuarioRepository.GetAsync(id);

            if (usuario is null)
            {
                return NotFound();
            }

            await _usuarioRepository.RemoveAsync(id);

            return NoContent();
        }

    }
}
