using System.Text.Json;

namespace RedditApp.Data.Repositories
{
    public class FileRepository<T> : IRepository<T> where T : class
    {
        private readonly string _filePath;

        public FileRepository(string filePath)
        {
            _filePath = filePath;
        }

        public List<T> GetAll()
        {
            return ReadFromFile();
        }

        public T GetById(int id)
        {
            return ReadFromFile().FirstOrDefault(x => GetId(x) == id);
        }

        public T Create(T entity)
        {
            var data = ReadFromFile();
            data.Add(entity);
            WriteToFile(data);
            return entity;
        }

        public T Update(T entity)
        {
            var data = ReadFromFile();
            var index = data.FindIndex(x => GetId(x) == GetId(entity));

            if (index != -1)
            {
                data[index] = entity;
                WriteToFile(data);
            }

            return entity;
        }

        public void Delete(int id)
        {
            var data = ReadFromFile();
            var entity = data.FirstOrDefault(x => GetId(x) == id);

            if (entity != null)
            {
                data.Remove(entity);
                WriteToFile(data);
            }
        }

        private List<T> ReadFromFile()
        {
            if (!File.Exists(_filePath))
            {
                File.Create(_filePath).Close();
                return new List<T>();
            }

            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        }

        private void WriteToFile(List<T> data)
        {
            var json = JsonSerializer.Serialize(data);
            File.WriteAllText(_filePath, json);
        }

        private int GetId(T entity)
        {
            var propertyInfo = entity.GetType().GetProperty("Id");
            return (int)propertyInfo.GetValue(entity);
        }
    }
}
