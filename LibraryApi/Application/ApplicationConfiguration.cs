using LibraryApi.Application.Authors.CreateAuthor;
using LibraryApi.Application.Authors.GetAuthor;
using LibraryApi.Application.Authors.ListAuthor;
using LibraryApi.Application.Authors.UpdateAuthor;
using LibraryApi.Application.Books.CreateBook;
using LibraryApi.Application.Books.GetBook;
using LibraryApi.Application.Books.Mappers;
using LibraryApi.Application.Services;
using LibraryApi.Application.Services.Authors;
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
            AddServices(builder);
            AddMappers(builder);

            return builder;
        }

        private static void AddMediator(WebApplicationBuilder builder)
        {
            builder.Services.AddMediatR(typeof(Program).Assembly);
        }

        private static void AddServices(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped(typeof(IBaseServices<>), typeof(BaseServices<>));

            // Author
            builder.Services.AddScoped<IAuthorServices, AuthorServices>();

            // Book
            builder.Services.AddScoped<IBookServices, BookServices>();

        }

        private static void AddMappers(WebApplicationBuilder builder)
        {
            // Author
            builder.Services.AddSingleton<ICreateAuthorCommandMapper, CreateAuthorCommandMapper>();
            builder.Services.AddSingleton<IGetAuthorQueryMapper, GetAuthorQueryMapper>();
            builder.Services.AddSingleton<IListAuthorQueryMapper, ListAuthorQueryMapper>();
            builder.Services.AddSingleton<IUpdateAuthorCommandMapper, UpdateAuthorCommandMapper>();

            // Book
            builder.Services.AddSingleton<ICreateBookCommandMapper, CreateBookCommandMapper>();
            builder.Services.AddSingleton<IAuthorMapper, AuthorMapper>();
            builder.Services.AddSingleton<IGetBookQueryMapper, GetBookQueryMapper>();


        }
    }
}