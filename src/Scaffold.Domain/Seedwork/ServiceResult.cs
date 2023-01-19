using System.Net;

namespace Scaffold.Domain.Seedwork;

public class ServiceResult<T> where T : class
{
    public ServiceResult(HttpStatusCode statusCode, T data)
    {
        StatusCode = statusCode;
        Success = true;
        Erros = new CustomProblemDetail();
        Data = data;
    }

    public ServiceResult(HttpStatusCode statusCode)
    {
        StatusCode = statusCode;
        Success = false;
        Erros = new CustomProblemDetail();
    }

    public ServiceResult(HttpStatusCode statusCode, string name, string error)
    {
        StatusCode = statusCode;
        Success = false;
        Erros = new CustomProblemDetail()
        {
            Detail = error,
            Fields = new List<FieldProblemDetail>()
            {
                new FieldProblemDetail()
                {
                    Name = name,
                    Message = error
                }
            }
        };
        Data = null;
    }

    public ServiceResult(HttpStatusCode statusCode, IEnumerable<string> errors)
    {
        StatusCode = statusCode;
        Success = false;
        Erros = BuildErrorsList(errors);
        Data = null;
    }


    public bool Success { get; private set; }
    public HttpStatusCode StatusCode { get; private set; }
    public CustomProblemDetail Erros { get; private set; }
    public T Data { get; private set; }


    private CustomProblemDetail BuildErrorsList(IEnumerable<string> validationFailures)
    {
        var errors = new CustomProblemDetail();

        foreach (var validationFailure in validationFailures)
            errors.AddField("", validationFailure);

        return errors;
    }
}