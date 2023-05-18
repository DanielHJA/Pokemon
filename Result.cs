namespace API
{
    public class Result<T>
    {
        public T? Data {get; set;}
        public bool Success {get; set;}
        public CustomException? Exception {get; set;}

        public Result(T? data, CustomException? exception, bool success)
        {
            Data = data;
            Exception = exception;
            Success = success;
        }
    }
}