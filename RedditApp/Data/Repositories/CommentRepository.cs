using RedditApp.Data.Models;
using RedditApp.Data.Repositories;

public class CommentRepository : FileRepository<Comment>
{
    public CommentRepository(string filePath) : base(filePath)
    {
    }
}