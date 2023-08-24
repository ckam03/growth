using System.Net;
using System.Text.Json;

namespace growth.Backend.Middleware;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try 
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            //maybe add a switch statement later to handle more than just 500
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var result = JsonSerializer.Serialize(new { error = ex.Message });
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(result);
        }
    }
}
