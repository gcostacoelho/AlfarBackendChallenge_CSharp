using System.Net;
using Newtonsoft.Json;

using AlfarBackendChallengeV2.src.Models.Utils;

namespace AlfarBackendChallengeV2.src.Middleware
{
    public class ApiExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public ApiExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            try
            {
                await _next(context);
            }

            catch (ApiException error)
            {
                var responseModel = ApiResponse<string>.Fail(error.Message, error.StatusCode);
                
                switch (error.StatusCode)
                {
                    case HttpStatusCode.NoContent:
                        response.StatusCode = (int)HttpStatusCode.NoContent;
                        break;

                    case HttpStatusCode.NotFound:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                }

                var result = JsonConvert.SerializeObject(responseModel);
                await response.WriteAsync(result);
            }

            catch (Exception error)
            {
                var responseModel = ApiResponse<string>.Fail(error.Message, HttpStatusCode.InternalServerError);
                response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var result = JsonConvert.SerializeObject(responseModel);
                await response.WriteAsync(result);
            }
        }
    }
}