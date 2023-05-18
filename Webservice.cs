namespace API
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    public static class Webservice<T>
    {
        public static async Task<Result<T>> Fetch(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage res = new HttpResponseMessage();

                try
                {
                    res = await client.GetAsync(url);
                }
                catch(Exception exception)
                {
                    return Result(default(T), exception, false); 
                }

                if(res.IsSuccessStatusCode)
                {
                    HttpContent content = res.Content;
                    string? data = String.Empty;

                    try
                    {
                        data = await content.ReadAsStringAsync();
                    }
                    catch(Exception exception)
                    {
                        return Result(default(T), exception, false); 
                    }
                    
                    if(data != null)
                    {
                        try
                        {
                            T? pokemon = JsonConvert.DeserializeObject<T>(data);
                            return Result(pokemon, true);
                        }
                        catch(Exception exception)
                        {
                            return Result(default(T), exception, false); 
                        }
                    }
                    else
                    {
                        return Result(default(T), "No data", false); 
                    }
                } 
                else
                {
                    return Result(default(T), "Unable to fetch data", false); 
                }
            }
        } 
    
        public static Result<T> Result(T? obj, bool success)
        {
            return new Result<T>(obj, null, success); 
        }

        public static Result<T> Result(T? obj, Exception? exception, bool success)
        {
            return new Result<T>(obj, exception, success); 
        }

        public static Result<T> Result(T? obj, string exceptionString, bool success)
        {
            var exception = new Exception(exceptionString);
            return new Result<T>(obj, exception, success); 
        }
    }
}
