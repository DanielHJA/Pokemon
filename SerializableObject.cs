using Newtonsoft.Json;

namespace API
{
    public class SerializableObject
    {
        public void PrintOutSerialized()
        {
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);
            Console.WriteLine(json);
        }
    }
}