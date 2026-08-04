using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using VigilyAPI.Models;

namespace VigilyAPI.Extensions
{
    public static class ApiExceptionMiddlewareExtension
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
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
                        await context.Response.WriteAsync(
                            new ErrorDetails()
                            {
                                StatusCode = context.Response.StatusCode,
                                Message = contextFeature.Error.Message,
                                Trace = app
                                    .ApplicationServices.GetRequiredService<IWebHostEnvironment>()
                                    .IsDevelopment()
                                    ? contextFeature.Error.StackTrace
                                    : null,
                            }.ToString()
                        );
                    }
                });
            });
        }
    }
}
