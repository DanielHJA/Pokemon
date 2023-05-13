namespace API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            string url = "https://pokeapi.co/api/v2/pokemon/charizard/";
            var result = await Webservice<Pokemon>.Fetch(url);

            if(result.Data != null)
            {
                result.Data.PrintOutSerialized();
            }
        }
    }
}