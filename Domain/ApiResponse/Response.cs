using System.Net;

namespace Domain.ApiResponse;

public class Response<T>
{
    public bool IsSucces { get; set; }
    public string? Message { get; set; }
    public T? Data { get; set; }
    public HttpStatusCode StatusCode { get; set; }

    public Response(T? data, string message)
    {
        IsSucces = true;
        Message = message;
        Data = data;
        StatusCode = HttpStatusCode.OK;

    }

    public Response(string message, HttpStatusCode statusCode)
    {
        IsSucces = false;
        Message = message;
        Data = default;
        StatusCode = statusCode;
    }
}
