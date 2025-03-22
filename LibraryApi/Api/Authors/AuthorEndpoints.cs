using LibraryApi.Application.Authors.CreateAuthor;
using LibraryApi.Application.Authors.DeleteAuthor;
using LibraryApi.Application.Authors.GetAuthor;
using LibraryApi.Application.Authors.ListAuthor;
using LibraryApi.Application.Authors.UpdateAuthor;
using MediatR;

namespace LibraryApi.Api.Authors
{
    /// <summary>
    /// Contains the complete Author's endpoints registration.
    /// </summary>
    public static class AuthorEndpoints{

        public static WebApplication Register(WebApplication application)
        {
            const string EntityName = "Author";

            application.MapPost("/api/author", async (CreateAuthorCommand command, IMediator mediator) =>
            {
                var authorId = await mediator.Send(command);
                return Results.Created($"api/author/{authorId}", authorId);
            })
            .WithTags(EntityName)
            .WithSummary($"Create an {EntityName}.");

            application.MapGet("/api/author", async (Guid id, IMediator mediator) =>
            {
                var author = await mediator.Send(new GetAuthorQuery(id));
                return Results.Ok(author);
            })
            .WithTags(EntityName)
            .WithSummary($"Retrieves an {EntityName} by ID.");

            application.MapGet("/api/author-list", async (IMediator mediator) =>
            {
                var listAuthors = await mediator.Send(new ListAuthorQuery());
                return Results.Ok(listAuthors);
            })
            .WithTags(EntityName)
            .WithSummary($"Retrieves all {EntityName}s.");

            application.MapPatch("/api/author", async (UpdateAuthorCommand command, IMediator mediator) =>
            {
                var result = await mediator.Send(command);
                return Results.NoContent();
            })
            .WithTags(EntityName)
            .WithSummary($"Update an {EntityName} by ID.");

            application.MapDelete("/api/author", async (Guid id, IMediator mediator) =>
            {
                var result = await mediator.Send(new DeleteAuthorCommand(id));
                return Results.Ok(result.Message);
            })
            .WithTags(EntityName)
            .WithSummary($"Delete an {EntityName} by ID.");

            return application;
        }
    }   
}
