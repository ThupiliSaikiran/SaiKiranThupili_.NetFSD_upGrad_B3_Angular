using Microsoft.AspNetCore.Http.HttpResults;
using System.Net;
using Contact_Management_Service.Exceptions;
using Contact_Management_Service.Models;
using System.Text.Json;

namespace Contact_Management_Service.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next,  ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred");

                await HandleExceptionAsync(context, ex);
            }
        }
        public static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var response = context.Response;
            response.ContentType = "application/json";  

            int statusCode = (int)HttpStatusCode.InternalServerError;
            string message = "Something went wrong";

            switch (ex)
            {
                case NotFoundException:
                    statusCode = (int)HttpStatusCode.NotFound;
                    message = ex.Message;
                    break;

                case BadRequestException:
                    statusCode = (int)HttpStatusCode.BadRequest;
                    message = ex.Message;
                    break;

                default:
                    message = "something went wrong";
                    break;

            }

            var errorResponse = new ErrorResponse
            {
                Message = message,
                StatusCode = statusCode,
                Timestamp = DateTime.UtcNow
            };


            var result = JsonSerializer.Serialize(errorResponse);
            response.StatusCode = statusCode;

            return response.WriteAsync(result); 
        }
    }
}
