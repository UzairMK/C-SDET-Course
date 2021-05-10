using System.IO;
using Newtonsoft.Json;

namespace Serialisation
{
    public class SerialiserJSON : ISerialise
    {
        public void SerialiseToFile<T>(string filePath, T item)
        {
            string jsonString = JsonConvert.SerializeObject(item);
            File.WriteAllText(filePath, jsonString);
        }

        public T DeserialiseFromFile<T>(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<T>(jsonString);
        }
    }
}
