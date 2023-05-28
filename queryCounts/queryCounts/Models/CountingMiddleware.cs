using System.Security.Cryptography;

namespace queryCounts.Models
{
    public class CountingMiddleware
    {
        private readonly RequestDelegate _next;
        private int _requestCount;

        public CountingMiddleware(RequestDelegate next)
        {
            _next = next;
          
        }

        public async Task InvokeAsync(HttpContext context)
        {
 
            _requestCount++;     
            await _next(context);
            await context.Response.WriteAsync("counts of requests " + _requestCount);
        } 
    }
}
  