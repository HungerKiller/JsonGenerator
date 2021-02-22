using Newtonsoft.Json;
using System.IO;

namespace JsonGenerator
{
    public class JsonWriter
    {
        public static void WriteJson(object obejct, string jsonFileName)
        {
            //open file stream
            using (StreamWriter file = File.CreateText(jsonFileName))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, obejct);
            }
        }
    }
}
