namespace API
{
    public class Result<T>
    {
        public T? Data {get; set;}
        public bool Success {get; set;}
        public Exception? Exception {get; set;}

        public Result(T? data, Exception? exception, bool success)
        {
            Data = data;
            Exception = exception;
            Success = success;
        }
    }
}