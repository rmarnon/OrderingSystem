namespace Ordering.System.Api.Exceptions
{
    public class ApiException : Exception
    {
        public ApiException(string message, Exception exception) : base(message, exception) { }
    }
}
