using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Threading.Tasks;

namespace AdaptItAcademy.WebAPI.Error_handlers
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        

        // include all possible exceptions in here.
        public async Task Invoke(HttpContext httpContext)
        {

            try
            {
                await _next(httpContext);
            }

            catch (Exception ex)
            {
                var response = httpContext.Response;
                response.ContentType = "application/json";

                switch (ex)
                {
                    case BadHttpRequestException badHttp:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;

                    case KeyNotFoundException knf:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;

                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                await response.WriteAsync(new ErrorDetails(response.StatusCode, ex.Message).ToString());
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
