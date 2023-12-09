using Microsoft.AspNetCore.Diagnostics;
using PatikaRestfulApi.Entities.ErrorModel;

namespace PatikaRestfulApi.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this WebApplication app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature is not null)
                    {

                        context.Response.StatusCode = contextFeature.Error switch
                        {                          
                            _ => StatusCodes.Status500InternalServerError 
                        };

                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message
                        }.ToString());

                    }
                });
            });
        }
    }
}
