using Microsoft.AspNetCore.Mvc;
using RedditApp.Data.Models;
using RedditApp.Services;

namespace RedditApp.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {

        private readonly PostService _postService;

        public PostController(PostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public ActionResult<List<Post>> GetAllPosts()
        {
            return _postService.GetAllPosts();
        }

        [HttpGet("{id}")]
        public ActionResult<Post> GetPostById(int id)
        {
            var post = _postService.GetPostById(id);

            if (post == null)
            {
                return NotFound();
            }

            return post;
        }

        [HttpPost]
        public ActionResult<Post> CreatePost(Post post)
        {
            _postService.CreatePost(post);
            return CreatedAtAction(nameof(GetPostById), new { id = post.Id }, post);
        }

        // Add more methods for updating, deleting posts, etc.
    }
}
