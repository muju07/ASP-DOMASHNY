using Microsoft.AspNetCore.Http;

public class TokeMiddleware
{
    private readonly RequestDelegate _next;
    private readonly string pattern;
    public TokeMiddleware(RequestDelegate next, string pattern)
    {
        this._next = next;
        this.pattern = pattern; 
    }
    public async Task InvokeAsync(HttpContext context)
    {
        var token = context.Request.Query["token"];
        if (token!="12345678")
        {
            context.Response.StatusCode = 403;
            await context.Response.WriteAsync("Token is invalid");
        }
        else
        {
            await _next.Invoke(context);
        }
        
        
    }
}