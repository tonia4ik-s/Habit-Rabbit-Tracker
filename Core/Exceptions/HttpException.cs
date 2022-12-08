using System.Net;
using System.Runtime.Serialization;

namespace Core.Exceptions;

[Serializable]
public class HttpException : ApplicationException
{
    public HttpStatusCode StatusCode { get; set; }
    public HttpException() { }
    public HttpException(string message, HttpStatusCode statusCode) : base(message)
    {
        StatusCode = statusCode;
    }
    public HttpException(string message, Exception inner) : base(message, inner) { }
    protected HttpException(
        SerializationInfo info,
        StreamingContext context) : base(info, context) { }
}
