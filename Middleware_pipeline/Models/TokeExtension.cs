public static class TokenExtension
{
    public static IApplicationBuilder UseToken(this IApplicationBuilder builder, string pattern) 
    {
        return builder.UseMiddleware<TokeMiddleware>(pattern);
    }
    public static IApplicationBuilder UsePathChecking(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<RoutingMiddleware>();
    }
}