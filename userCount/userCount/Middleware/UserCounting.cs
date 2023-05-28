using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using userCount.Models;

namespace userCount.Middleware
{
    public class UserCounting
    {
        private readonly RequestDelegate del;
        private int temp;
        public UserCounting(RequestDelegate _del)
        {
            this.del = _del;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                if (context.Request.Host.Host == "localhost")
                {
                    temp++;

                    if (!context.Response.HasStarted)
                    {
                        context.Response.Headers.Add("X-User-Count", temp.ToString());
                        await context.Response.WriteAsync("Count of users on the page: " + temp);
                    }
                }

                await del.Invoke(context);
            }
            catch (Exception ex)
            {
                 Debug.WriteLine(ex.Message);
            }
        }
    }
}
