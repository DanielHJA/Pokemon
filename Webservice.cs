namespace API
{
    using System.Net.Http;
    using Newtonsoft.Json.Linq;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    public static class Webservice<T>
    {
        public static async Task<Result<T>> Fetch(string url)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage res = new HttpResponseMessage();

                    try
                    {
                        res = await client.GetAsync(url);
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine("Something went wrong while trying to fetch the data: " + e.Message);
                    }

                    if(res.IsSuccessStatusCode)
                    {
                        HttpContent content = res.Content;
                        var data = await content.ReadAsStringAsync();

                        if(data != null)
                        {
                            try
                            {
                                T? pokemon = JsonConvert.DeserializeObject<T>(data);
                                return new Result<T>(pokemon, null, true); 
                            }
                            catch(Exception e)
                            {
                                Console.WriteLine("Something went wrong while trying to serialize the data: " + e.Message);
                                return new Result<T>(default(T), e.Message, false); 
                            }
                        }
                        else
                        {
                            Console.WriteLine("No data");
                            return new Result<T>(default(T), "No data", false); 
                        }
                    } 
                    else
                    {
                        Console.WriteLine("Unable to fetch data");
                        return new Result<T>(default(T), "Unable to fetch data", false); 
                    }
                }
            } 
            catch(HttpRequestException e)
            {
                Console.WriteLine("Something went wrong while trying to fetch data: " + e.Message);
                return new Result<T>(default(T), e.Message, false); 
            }
        }
    }
}