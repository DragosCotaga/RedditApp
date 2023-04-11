using RedditApp.Data.Models;

namespace RedditApp.Services
{
    public class PostService
    {
        private readonly PostRepository _postRepository;

        public PostService(PostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public List<Post> GetAllPosts()
        {
            return _postRepository.GetAll();
        }

        public Post GetPostById(int id)
        {
            return _postRepository.GetById(id);
        }

        public Post CreatePost(Post post)
        {
            return _postRepository.Create(post);
        }

        public Post UpdatePost(Post post)
        {
            return _postRepository.Update(post);
        }

        public void DeletePost(int id)
        {
            _postRepository.Delete(id);
        }
    }
}
