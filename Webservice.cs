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
                    return Result(default(T), exception, -2, false); 
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
                        return Result(default(T), exception, -4, false); 
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
                            return Result(default(T), exception, -3, false); 
                        }
                    }
                    else
                    {
                        return Result(default(T), "No data", -2, false); 
                    }
                } 
                else
                {
                    return Result(default(T), "Unable to fetch data", -1, false); 
                }
            }
        } 
    
        public static Result<T> Result(T? obj, bool success)
        {
            return new Result<T>(obj, null, success); 
        }

        public static Result<T> Result(T? obj, Exception exception, int errorCode, bool success)
        {
            CustomException e = new CustomException(exception.Message, errorCode); 
            return new Result<T>(obj, e, success); 
        }

        public static Result<T> Result(T? obj, string exceptionString, int errorCode, bool success)
        {
            var exception = new CustomException(exceptionString, errorCode);
            return new Result<T>(obj, exception, success); 
        }
    }
}
