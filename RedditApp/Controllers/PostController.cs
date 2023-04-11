using Microsoft.AspNetCore.Mvc;
using RedditApp.Data.Models;
using RedditApp.Services;

namespace RedditApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly PostRepository _postRepository;

        public PostController(PostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpGet]
        public IEnumerable<Post> GetPosts()
        {
            return _postRepository.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Post> GetPost(int id)
        {
            var post = _postRepository.GetById(id);
            if (post == null)
            {
                return NotFound();
            }
            return post;
        }

        [HttpPost]
        public ActionResult<Post> CreatePost(Post post)
        {
            _postRepository.Create(post);
            return CreatedAtAction(nameof(GetPost), new { id = post.Id }, post);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePost(int id, Post post)
        {
            if (id != post.Id)
            {
                return BadRequest();
            }
            _postRepository.Update(post);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePost(int id)
        {
            _postRepository.Delete(id);
            return NoContent();
        }
    }
}
