namespace HospitalApp.Middlewares
{
    public static class MyMiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorHandling(this IApplicationBuilder builder) 
        {
            return builder.UseMiddleware<ExceptionsMiddleware>();
        }
    }
}
