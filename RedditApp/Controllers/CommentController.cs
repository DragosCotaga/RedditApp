using Microsoft.AspNetCore.Mvc;
using RedditApp.Data.Models;
using RedditApp.Services;

namespace RedditApp.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CommentController
    {


        private readonly CommentService _commentService;

        public CommentController(CommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public ActionResult<List<Comment>> GetAllComments()
        {
            return _commentService.GetAllComments();
        }

        [HttpGet("{id}")]
        public ActionResult<Comment> GetCommentById(int id)
        {
            var comment = _commentService.GetCommentById(id);

            if (comment == null)
            {
                return NotFound();
            }

            return comment;
        }

        [HttpPost]
        public ActionResult<Comment> CreateComment(Comment comment)
        {
            _commentService.CreateComment(comment);
            return CreatedAtAction(nameof(GetCommentById), new { id = comment.Id }, comment);
        }

        // Add more methods for updating, deleting comments, etc.
    }
}
