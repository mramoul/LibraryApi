using LibraryApi.Application.Books.CreateBook;
using MediatR;

namespace LibraryApi.Api.Books
{
    /// <summary>
    /// Contains the complete Book's endpoints registration.
    /// </summary>
    public static class BookEndpoints{

        public static WebApplication Register(WebApplication application)
        {
            const string EntityName = "book";

            application.MapPost($"/api/{EntityName}", async (CreateBookCommand command, IMediator mediator) =>
            {
                var bookId = await mediator.Send(command);
                return Results.Created($"api/{EntityName}/{bookId}", bookId);
            })
            .WithTags(EntityName)
            .WithSummary($"Create a {EntityName}.");

            return application;
        }
    }   
}
