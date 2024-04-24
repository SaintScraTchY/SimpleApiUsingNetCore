using System.Net;
using MediatR;

namespace NS.Application.Common;

public class BaseResponse
{
    public bool IsSucceeded { get; set; }
    public string Message { get; set; } = string.Empty;
    public HttpStatusCode ResponseCode { get; set; }
    public List<string> ValidationErrors { get; set; } = new List<string>();
    public BaseResponse()
    {
        
    }

    public void Failed(HttpStatusCode responseCode,string message,List<string>? validationErrors)
    {
        IsSucceeded = false;
        ResponseCode = responseCode;
        Message = message;
    }

    public void Succeeded(HttpStatusCode responseCode,string message)
    {
        IsSucceeded = true;
        ResponseCode = responseCode;
        Message = message;
    }
}