using RedditApp.Data.Models;
using RedditApp.Data.Repositories;

public class PostRepository : FileRepository<Post>
{
    public PostRepository(string filePath) : base(filePath)
    {
    }

    public void Update(Post entity)
    {
        var posts = GetAll().ToList();
        var index = posts.FindIndex(p => p.Id == entity.Id);
        if (index != -1)
        {
            posts[index] = entity;
            base.Save(posts);
        }
    }
}