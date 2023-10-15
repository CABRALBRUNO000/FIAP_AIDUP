using AidUp.Models;
using AidUp.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AidUp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {

        private readonly PostRepository _postRepository;

        public PostController(PostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpGet]
        public async Task<List<PostModel>> Get() =>
            await _postRepository.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<PostModel>> Get(string id)
        {
            var post = await _postRepository.GetAsync(id);

            if (post is null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PostModel newPost)
        {
            await _postRepository.CreateAsync(newPost);

            return CreatedAtAction(nameof(Get), new { id = newPost.IdPost }, newPost);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, PostModel updatedPost)
        {
            var post = await _postRepository.GetAsync(id);

            if (post is null)
            {
                return NotFound();
            }

            updatedPost.IdPost = post.IdPost;

            await _postRepository.UpdateAsync(id, updatedPost);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var post = await _postRepository.GetAsync(id);

            if (post is null)
            {
                return NotFound();
            }

            await _postRepository.RemoveAsync(id);

            return NoContent();
        }

    }
}
