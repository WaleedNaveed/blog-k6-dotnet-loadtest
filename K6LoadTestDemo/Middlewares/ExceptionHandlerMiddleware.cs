using Newtonsoft.Json;

namespace K6LoadTestDemo.Middlewares
{
    public class ExceptionHandlerMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception)
            {
                var errorResponse = new ErrorResponse
                {
                    ErrorMessage = "Something went wrong.",
                    ErrorCode = 500
                };

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = errorResponse.ErrorCode;
                await context.Response.WriteAsync(JsonConvert.SerializeObject(errorResponse));
            }
        }
    }

    public class ErrorResponse
    {
        public string ErrorMessage { get; set; }
        public int ErrorCode { get; set; }
    }
}