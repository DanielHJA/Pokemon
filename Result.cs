namespace API
{
    public class Result<T>
    {
        public T? Data {get; set;}
        public bool Success {get; set;}
        public string? Message {get; set;}

        public Result(T? data, string? message, bool success)
        {
            Data = data;
            Message = message;
            Success = success;
        }
    }
}