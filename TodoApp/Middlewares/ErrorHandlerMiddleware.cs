using System.Net;
using System.Text.Json;
using FluentValidation;
using TodoApp.Models;

namespace TodoApp.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ILogger<ErrorHandlerMiddleware> logger)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;

                response.ContentType = "application/json";

                ApiResponse<string> responseModel;
                switch (error)
                {
                    case ValidationException e:
                        // custom application error
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseModel = ApiResponse<string>.Fail(error.Message);
                        break;
                    case ApplicationException e:
                        // custom application error
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseModel = ApiResponse<string>.Fail(error.Message);
                        break;
                    case KeyNotFoundException e:
                        // not found error
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        responseModel = ApiResponse<string>.Fail(error.Message);
                        break;
                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        responseModel = ApiResponse<string>.Fail("Sistemde teknik bir hata oluştu. Lütfen sistem yetkilileri ile irtibata geçiniz.");
                        break;
                }

                logger.LogError(error, string.Empty);

                var result = JsonSerializer.Serialize(responseModel);

                await response.WriteAsync(result);
            }
        }
    }
}

