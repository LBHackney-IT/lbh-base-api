using BaseApi.V1.Controllers;
using Hackney.Core.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi
{
    public static class ExceptionMiddlewareExtensions
    {
        [ExcludeFromCodeCoverage]
        public static void UseCustomExceptionHandler(this IApplicationBuilder app, ILogger logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    await HandleExceptions(context, logger).ConfigureAwait(false);
                });
            });
        }

        public static async Task HandleExceptions(HttpContext context, ILogger logger)
        {
            context.Response.ContentType = "application/json";
            string message = "Internal Server Error.";

            var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
            if (contextFeature != null)
            {
                switch (contextFeature.Error)
                {
                    // TODO: Handle our specific errors here.

                    case Exception ex:
                        message = ex.Message;
                        break;
                    default:
                        break;
                }

                logger.LogError(contextFeature.Error, "Request failed.");
            }

            var correlationId = context.Request.Headers.GetHeaderValue(HeaderConstants.CorrelationId);
            var exceptionResult = new ExceptionResult(message, context.TraceIdentifier,
                correlationId, context.Response.StatusCode);
            await context.Response.WriteAsync(exceptionResult.ToString()).ConfigureAwait(false);
        }
    }
}
