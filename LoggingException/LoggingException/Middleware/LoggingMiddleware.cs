using System.Runtime.CompilerServices;

namespace LoggingException.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;
        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            this._next = next;
            this._logger= logger;
        }

     

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
                throw new Exception();
            }
            catch (Exception ex)
            {
                
                LogException(ex);
                
            }


        }
        private void LogException(Exception ex)
        {
            
            string logMessage = $"Exception: {ex.Message}\nStackTrace: {ex.StackTrace}";

            string logFilePath = "Logs/File.log";
            using (StreamWriter writer = File.AppendText(logFilePath))
            {
                writer.WriteLine(logMessage);
            }

       
            _logger.LogError(logMessage);
        }


    }
}
