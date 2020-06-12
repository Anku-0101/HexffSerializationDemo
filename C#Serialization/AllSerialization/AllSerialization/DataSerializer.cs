using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AllSerialization
{
    public class DataSerializer
    {
        #region BinarySerializationAndDeserialization

        public void BinarySerialize(object data, string filePath)
        {
            FileStream stream;
            BinaryFormatter bf = new BinaryFormatter();

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            stream = File.Create(filePath);
            bf.Serialize(stream, data); //Serialization 

            stream.Close();
        }

        public object BinaryDeserialize(string filepath)
        {
            object obj = null;

            FileStream stream;
            BinaryFormatter bf = new BinaryFormatter();

            if (File.Exists(filepath))
            {
                stream = File.OpenRead(filepath);
                obj = bf.Deserialize(stream); //Deserialization
                stream.Close();
            }
            return obj;
        }
        #endregion

        #region XMLSerializationAndDeserialization

        public void XmlSerialize(Type dataType, object data, string filePath)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(dataType);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            TextWriter textWriter = new StreamWriter(filePath);

            xmlSerializer.Serialize(textWriter, data); // Serialization
            textWriter.Close();
        }

        public object XmlDeserialize(Type dataType, string filePath)
        {
            Object obj = null;

            XmlSerializer xmlSerializer = new XmlSerializer(dataType);

            if (File.Exists(filePath))
            {
                TextReader textReader = new StreamReader(filePath);
                obj = xmlSerializer.Deserialize(textReader);
                textReader.Close();
            }

            return obj;
        }

        #endregion

        #region JSONSerializationAndDeserialization
        public void JsonSerialize(object data, string filePath)
        {
            JsonSerializer jsonSerializer = new JsonSerializer();
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            StreamWriter streamWriter = new StreamWriter(filePath);

            JsonWriter jsonWriter = new JsonTextWriter(streamWriter);
            jsonSerializer.Serialize(jsonWriter, data);

            jsonWriter.Close();
            streamWriter.Close();

        }

        public object JsonDeSerialize(Type dataType, string filePath)
        {
            JObject obj = null;

            JsonSerializer jsonSerializer = new JsonSerializer();
            if (File.Exists(filePath))
            {
                StreamReader streamReader = new StreamReader(filePath);
                JsonReader jsonReader = new JsonTextReader(streamReader);
                obj = jsonSerializer.Deserialize(jsonReader) as JObject;
                jsonReader.Close();
                streamReader.Close();

            }
            return obj.ToObject(dataType);
        }
        #endregion

    }
}

