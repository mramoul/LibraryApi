using LibraryApi.Application.Authors;
using MediatR;

namespace LibraryApi.Application
{
    /// <summary>
    /// This class provides an extension method to register the application related services in the web application.
    //  It ensures that specific Application DI are added during application startup, simplifying application layer management.
    /// </summary>
    public static class ApplicationConfiguration
    {
        public static WebApplicationBuilder AddApplicationServices(this WebApplicationBuilder builder)
        {
            AddMediator(builder);
            AddMappers(builder);

            return builder;
        }

        private static void AddMediator(WebApplicationBuilder builder)
        {
            builder.Services.AddMediatR(typeof(Program).Assembly);
        }

        private static void AddMappers(WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<ICreateAuthorCommandMapper, CreateAuthorCommandMapper>();
        }
    }
}