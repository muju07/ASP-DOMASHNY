public class RoutingMiddleware
{
    private readonly RequestDelegate requestDelegate;
    public RoutingMiddleware(RequestDelegate del)
    {
        this.requestDelegate = del;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        var path = context.Request.Path.Value.ToLower();
        if(path == "/index")
        {
            await context.Response.WriteAsync("index page");
        }
        else if(path == "/test")
        {
            await context.Response.WriteAsync("test page");
        }
    }
}