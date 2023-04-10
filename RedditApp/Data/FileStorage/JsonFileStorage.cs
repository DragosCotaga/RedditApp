using System.Text.Json;

namespace RedditApp.Data.FileStorage
{
    public class JsonFileStorage<T>
    {
        private readonly string _filePath;

        public JsonFileStorage(string filePath)
        {
            _filePath = filePath;
        }

        public List<T> ReadFromFile()
        {
            if (!File.Exists(_filePath))
            {
                File.Create(_filePath).Close();
                return new List<T>();
            }

            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        }

        public void WriteToFile(List<T> data)
        {
            var json = JsonSerializer.Serialize(data);
            File.WriteAllText(_filePath, json);
        }
    }
}
