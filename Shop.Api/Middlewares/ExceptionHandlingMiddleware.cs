using Common.Logger.DefaultLogger;
using FluentValidation;
using FluentValidation.Results;
using System.Net;
using System.Text.Json;

namespace Shop.Api.Middlewares
{
    internal sealed class ExceptionHandlingMiddleware : IMiddleware
    {
        private readonly IDefaultLogger _logger;

        public ExceptionHandlingMiddleware(IDefaultLogger logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
                await HandleExceptionAsync(context, e);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception e)
        {
            var detail = e.Message;
            var errors = GetValidationErrors(e);

            var statusCode = e switch
            {
                ValidationException => (int)HttpStatusCode.BadRequest,
                _ => (int)HttpStatusCode.BadRequest
            };

            var response = new
            {
                status = statusCode,
                detail = detail,
                errors = errors
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }

        private static IEnumerable<ValidationFailure> GetValidationErrors(Exception e)
        {
            IEnumerable<ValidationFailure> errors = new List<ValidationFailure>();

            if (e is ValidationException validationException)
            {
                errors = validationException.Errors;
            }

            return errors;
        }
    }
}
