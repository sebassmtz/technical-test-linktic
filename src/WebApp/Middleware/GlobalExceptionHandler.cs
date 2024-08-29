
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using TechnicalTest.Domain.Common.Exceptions;
using TechnicalTest.Domain.Users.Exceptions;

namespace WebApp.Middleware
{
    public class GlobalExceptionHandler : IMiddleware
    {

        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (UnauthorizedAccessException unAuthEx)
            {
                _logger.LogError($"Unauthorized access: {unAuthEx.Message}", unAuthEx);
                var problemDetails = new ProblemDetails
                {
                    Status = StatusCodes.Status401Unauthorized,
                    Title = "Unauthorized",
                    Detail = unAuthEx.Message,
                    Instance = context.Request.Path
                };
                context.Response.StatusCode = problemDetails.Status.Value;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonSerializer.Serialize(problemDetails));
            }
            catch (AppDomainException appDoEx)
            {
                _logger.LogError($"Ha ocurrido un error: {appDoEx.Message}", appDoEx);
                var problemDetails = new ProblemDetails
                {
                    Status = StatusCodes.Status400BadRequest,
                    Title = "Application Domain Error",
                    Detail = appDoEx.Message,
                    Instance = context.Request.Path
                };
                context.Response.StatusCode = problemDetails.Status.Value;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonSerializer.Serialize(problemDetails));
            }
            catch (UserDomainException usDoEx)
            {
                _logger.LogError($"Ha ocurrido un error: {usDoEx.Message}", usDoEx);
                var problemDetails = new ProblemDetails
                {
                    Status = StatusCodes.Status400BadRequest,
                    Title = "User Domain Error",
                    Detail = usDoEx.Message,
                    Instance = context.Request.Path
                };
                context.Response.StatusCode = problemDetails.Status.Value;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonSerializer.Serialize(problemDetails));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ha ocurrido un error: {ex.Message}", ex);
                var problemDetails = new ProblemDetails
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Title = "Internal Server Error",
                    Detail = ex.Message,
                    Instance = context.Request.Path
                };
                context.Response.StatusCode = problemDetails.Status.Value;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonSerializer.Serialize(problemDetails));
            }
        }
    }
}
