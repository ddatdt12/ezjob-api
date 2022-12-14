using EzjobApi.Error;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace EzjobApi.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
            public static void ConfigureExceptionHandler(this IApplicationBuilder app,
           ILogger logger)
            {
                app.UseExceptionHandler(appError =>
                {
                    appError.Run(async context =>
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        context.Response.ContentType = "application/json";
                        var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                        if (contextFeature != null)
                        {
                            logger.LogError($"Something went wrong: {contextFeature.Error}");
                            await context.Response.WriteAsync(new HttpResponseException("Internal Server Error.")
                            {
                                StatusCode = context.Response.StatusCode,
                            }.ToString());
                        }
                    });
                });
        }

    }
}
