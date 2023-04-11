using RedditApp.Data.Models;

namespace RedditApp.Services
{
    public class CommentService
    {
        private readonly CommentRepository _commentRepository;

        public CommentService(CommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public List<Comment> GetAllComments()
        {
            return _commentRepository.GetAll();
        }

        public Comment GetCommentById(int id)
        {
            return _commentRepository.GetById(id);
        }

        public Comment CreateComment(Comment comment)
        {
            return _commentRepository.Create(comment);
        }

        public Comment UpdateComment(Comment comment)
        {
            return _commentRepository.Update(comment);
        }

        public void DeleteComment(int id)
        {
            _commentRepository.Delete(id);
        }
    }
}
