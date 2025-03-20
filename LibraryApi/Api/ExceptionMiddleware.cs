using LibraryApi.Application.Errors;

namespace LibraryApi.Api
{
    public class ExceptionMiddleware(RequestDelegate next)
    {
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = ex switch
                {
                    NotFoundError => StatusCodes.Status404NotFound,
                    _ => StatusCodes.Status500InternalServerError
                };

                await context.Response.WriteAsJsonAsync(new { error = ex.Message });
            }
        }
    }
}

