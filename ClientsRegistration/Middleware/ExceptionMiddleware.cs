using ClientsRegistration.Api.Middleware;
using ClientsRegistration.Infra;
using System.Net;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    public ExceptionMiddleware(RequestDelegate next)
    {

        _next = next;
    }
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }
    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        string mess = exception.Message;

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        if (exception is ClientNotFoundException)
        {
            mess = exception.Message;
            context.Response.StatusCode = 404;
        }
        else
        {
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync(
                new ErrorDetails()
                {
                    Message = mess,
                }.ToString());
        }

    }
}