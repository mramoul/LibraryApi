using LibraryApi.Application.Books.CreateBook;
using LibraryApi.Application.Books.DeleteBook;
using LibraryApi.Application.Books.GetBook;
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
            .WithTags(EntityName.ToUpper())
            .WithSummary($"Create a {EntityName}.");

            application.MapGet($"/api/{EntityName}", async (Guid id, IMediator mediator) =>
            {
                var author = await mediator.Send(new GetBookQuery(id));
                return Results.Ok(author);
            })
            .WithTags(EntityName.ToUpper())
            .WithSummary($"Retrieves a {EntityName} by ID.");

            application.MapDelete($"/api/{EntityName}", async (Guid id, IMediator mediator) =>
            {
                var result = await mediator.Send(new DeleteBookCommand(id));
                return Results.Ok(result.Message);
            })
            .WithTags(EntityName.ToUpper())
            .WithSummary($"Delete a {EntityName} by ID.");

            return application;
        }
    }   
}
