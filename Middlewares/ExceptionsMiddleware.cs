using System.IO;

namespace HospitalApp.Middlewares
{
    public class ExceptionsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _path = "logs.txt";

        public ExceptionsMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                await HandleException(httpContext, e);
            }
        }

        public async Task HandleException(HttpContext httpContext, Exception exc)
        {
            await _next(httpContext);
            using var stream = new StreamWriter(_path, true);
            await stream.WriteLineAsync($"{DateTime.Now},{httpContext.TraceIdentifier}, Message : {exc.Message}, StackTrace: {exc.StackTrace}");
            
        }
    }
}