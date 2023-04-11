using RedditApp.Data.Models;
using RedditApp.Data.Repositories;

public class UserRepository : FileRepository<User>
{
    public UserRepository(string filePath) : base(filePath)
    {
    }

    public void Update(User entity)
    {
        var users = GetAll().ToList();
        var index = users.FindIndex(u => u.Id == entity.Id);
        if (index != -1)
        {
            users[index] = entity;
            Save(users);
        }
    }
}