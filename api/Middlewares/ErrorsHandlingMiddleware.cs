using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using api.Contracts.V1.Exceptions;

namespace api.Middlewares
{
    public class ErrorsHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorsHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var exceptionType = exception.GetType();

            if (exceptionType == typeof(ValidationException))
            {
                var code = HttpStatusCode.BadRequest;
                var result = JsonConvert.SerializeObject(((ValidationException)exception).Errors);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)code;

                return context.Response.WriteAsync(result);
            }
            else if (exceptionType == typeof(BadRequestException))
            {
                var code = HttpStatusCode.BadRequest;
                var result = JsonConvert.SerializeObject(((BadRequestException)exception).Errors);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)code;

                return context.Response.WriteAsync(result);
            }
            else if (exceptionType == typeof(NotFoundException))
            {
                var code = HttpStatusCode.NotFound;
                context.Response.ContentType = "aplication/json";
                context.Response.StatusCode = (int)code;

                return context.Response.WriteAsync("");
            }
            else if (exceptionType == typeof(ArgumentNullException))
            {
                var code = HttpStatusCode.BadRequest;
                var result = JsonConvert.SerializeObject(new { ApiErr = exception.Message });
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)code;

                return context.Response.WriteAsync(result);
            }
            else
            {
                var code = HttpStatusCode.InternalServerError;
                var result = JsonConvert.SerializeObject(new { ApiErr = exception.Message });
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)code;

                return context.Response.WriteAsync(result);
            }
        }
    }
}