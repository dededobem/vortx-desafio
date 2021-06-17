using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Vortx.Application.Exceptions;

namespace Vortx.Api.Configurations.Middleware
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorMiddleware(RequestDelegate next) => _next = next;        
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                if(error.InnerException != null) 
                    error = error.InnerException;

                switch (error)
                {
                    case ApiException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case KeyNotFoundException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var responseException = new ResponseException<string>()
                {
                    StatusCode = response.StatusCode,
                    Message = error?.Message
                };

                var result = JsonSerializer.Serialize(responseException);

                await response.WriteAsync(result);
            }
        }
    }
}
