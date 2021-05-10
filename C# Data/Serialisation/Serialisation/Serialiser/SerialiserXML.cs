using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Serialisation
{
    public class SerialiserXML : ISerialise
    {
        public void SerialiseToFile<T>(string filePath, T item)
        {
            FileStream fileStream = File.Create(filePath);
            //Create BinaryFormatter object, and use it 
            XmlSerializer writer = new(item.GetType());
            writer.Serialize(fileStream, item);
            fileStream.Close();
        }

        public T DeserialiseFromFile<T>(string filePath)
        {
            Stream fileStream = File.OpenRead(filePath);
            XmlSerializer reader = new(typeof(T));
            var deserialisedItem = (T)reader.Deserialize(fileStream);
            return deserialisedItem;
        }
    }
}
