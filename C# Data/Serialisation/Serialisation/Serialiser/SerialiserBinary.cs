using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serialisation
{
    class SerialiserBinary : ISerialise
    {
        public void SerialiseToFile<T>(string filePath, T item)
        {
            FileStream fileStream = File.Create(filePath);
            //Create BinaryFormatter object, and use it 
            BinaryFormatter writer = new();
            writer.Serialize(fileStream, item);
            fileStream.Close();
        }

        public T DeserialiseFromFile<T>(string filePath)
        {
            Stream fileStream = File.OpenRead(filePath);
            BinaryFormatter reader = new();
            var deserialisedItem = (T)reader.Deserialize(fileStream);
            return deserialisedItem;
        }
    }
}
