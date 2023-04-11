using Microsoft.AspNetCore.Mvc;
using RedditApp.Data.Models;
using RedditApp.Services;

namespace RedditApp.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly CommentRepository _commentRepository;

        public CommentController(CommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        [HttpGet]
        public IEnumerable<Comment> GetComments()
        {
            return _commentRepository.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Comment> GetComment(int id)
        {
            var comment = _commentRepository.GetById(id);
            if (comment == null)
            {
                return NotFound();
            }
            return comment;
        }

        [HttpPost]
        public ActionResult<Comment> CreateComment(Comment comment)
        {
            _commentRepository.Create(comment);
            return CreatedAtAction(nameof(GetComment), new { id = comment.Id }, comment);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateComment(int id, Comment comment)
        {
            if (id != comment.Id)
            {
                return BadRequest();
            }
            _commentRepository.Update(comment);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteComment(int id)
        {
            _commentRepository.Delete(id);
            return NoContent();
        }
    }
}
