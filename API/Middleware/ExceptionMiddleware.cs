using API.Dtos;
using API.Exceptions;
using API.Extensions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, IHostEnvironment env)
        {
            _next = next;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";

                var apiResponse = new ApiErrorResponse<object>();
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                    apiResponse.Message = contextFeature.Error.Message;
                }
               
                switch (ex)
                {
                    case ApiException e:
                        apiResponse.StatusCode = e.StatusCode;
                        apiResponse.Message = e.Message;
                        apiResponse.ErrorCode = e.ErrorCode;
                        apiResponse.Errors = e.Errors;
                        break;

                    case KeyNotFoundException e:
                        // not found error
                        apiResponse.StatusCode = (int)HttpStatusCode.NotFound;
                        apiResponse.Message = "Nu s-a gasit cheia. Contactati suportul tehnic daca problema persista.";
                        //_logger.LogError(message: "Something went wrong: " + errorResponse.message);
                        break;

                    case NullReferenceException e:
                        apiResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                        apiResponse.Message = "Au aparut niste probleme. Incercati peste cateva minute.";
                        //_logger.LogError(message: ErrorMessage.NullReferencePrefix + e.Message, e);
                        break;

                    default:
                        // unhandled error
                        apiResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                        apiResponse.Message = "Eroare interna server. Contactati suportul tehnic daca problema persista.";
                        //_logger.LogError(message: " --- UNHANDLED ERROR: --- " + errorResponse.message, e: error);
                        break;
                }

                context.Response.StatusCode = apiResponse.StatusCode;
                await context.Response.WriteAsync(apiResponse.Serialize());
            }
        }
    }
}
