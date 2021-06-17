namespace Vortx.Application.Exceptions

{
    public class ResponseException<T>
    {
        public ResponseException() { }
        public ResponseException(string message, int statusCode)
        {
            Message = message;
            StatusCode = statusCode;
        }
        public int StatusCode { get; set; }
        public string Message { get; set; }

    }
}
