using LibraryApi.Application.Authors;
using MediatR;

namespace LibraryApi.Application
{
    public static class ApplicationServices
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