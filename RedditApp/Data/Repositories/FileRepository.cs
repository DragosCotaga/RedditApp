using RedditApp.Data.FileStorage;
using System.Text.Json;

namespace RedditApp.Data.Repositories
{
    public class FileRepository<T> : IRepository<T> where T : class
    {
        private readonly JsonFileStorage<T> _fileStorage;

        public FileRepository(string filePath)
        {
            _fileStorage = new JsonFileStorage<T>(filePath);
        }

        public List<T> GetAll()
        {
            return _fileStorage.ReadFromFile();
        }

        public T GetById(int id)
        {
            return GetAll().FirstOrDefault(x => GetId(x) == id);
        }

        public T Create(T entity)
        {
            var data = GetAll();
            data.Add(entity);
            _fileStorage.WriteToFile(data);
            return entity;
        }

        public T Update(T entity)
        {
            var data = GetAll();
            var index = data.FindIndex(x => GetId(x) == GetId(entity));

            if (index != -1)
            {
                data[index] = entity;
                _fileStorage.WriteToFile(data);
            }

            return entity;
        }

        public void Delete(int id)
        {
            var data = GetAll();
            var entity = data.FirstOrDefault(x => GetId(x) == id);

            if (entity != null)
            {
                data.Remove(entity);
                _fileStorage.WriteToFile(data);
            }
        }

        private int GetId(T entity)
        {
            var propertyInfo = entity.GetType().GetProperty("Id");
            return (int)propertyInfo.GetValue(entity);
        }
    }
}
