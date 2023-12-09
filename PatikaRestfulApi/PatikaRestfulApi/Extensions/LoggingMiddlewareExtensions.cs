namespace PatikaRestfulApi.Extensions
{
    public static class LoggingMiddlewareExtensions
    {
        public static void UseLoggingMiddleware(this WebApplication app)
        {
             app.UseMiddleware<LoggingMiddleware>();
        }
    }
}
