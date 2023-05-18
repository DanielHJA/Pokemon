public class CustomException : Exception
{
    public CustomException(){}

    public override string Message { get; } = "Undefined exception";
    public int ErrorCode { get; set; }

    public CustomException(string message, int errorCode)
    : base(String.Format(string.Format("Message: {0} | Error code: {1}"), message, errorCode))
    {
        Message = message;
        ErrorCode = errorCode;
    }
}