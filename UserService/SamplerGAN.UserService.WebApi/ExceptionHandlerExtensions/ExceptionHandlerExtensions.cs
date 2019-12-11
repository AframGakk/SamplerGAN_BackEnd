using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using SamplerGAN.UserService.Models.Exceptions;

namespace SamplerGAN.UserService.WebApi.ExceptionHandlerExtensions
{
    public static class ExceptionHandlerExtensions
    {
        public static void UseGlobalExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(error => {
                error.Run(async context => 
                {
                    var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var exception = exceptionHandlerFeature.Error;
                    var statusCode = (int) HttpStatusCode.InternalServerError; // Default status code => Internal server error (500)

                    if (exception is ResourceNotFoundException)
                    {
                        statusCode = (int) HttpStatusCode.NotFound;
                    }
                    else if (exception is UnauthorizedException)
                    {
                        statusCode = (int) HttpStatusCode.Unauthorized;
                    }
                    else if (exception is RequestElementsNeededException)
                    {
                        statusCode = (int) HttpStatusCode.PreconditionFailed;
                    }
                    // More errors ?
                    
                    context.Response.ContentType = "application/json"; // ContentType header as application/json
                    context.Response.StatusCode = statusCode; // This is needed to get the right Statuscode header in postman

                    // Return the respone to the client
                    await context.Response.WriteAsync(new ExceptionModel
                    {
                        StatusCode = statusCode,
                        ExceptionMessage = exception.Message
                    }.ToString());
                });
            });
        }
    }
}