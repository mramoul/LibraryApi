using LibraryApi.Application.Authors;
using LibraryApi.Application.Authors.GetAuthor;
using MediatR;

namespace LibraryApi.Api.Authors
{
    /// <summary>
    /// Contains the complete Author's endpoints registration.
    /// </summary>
    public static class AuthorEndpoints{

        public static WebApplication Register(WebApplication application)
        {
            application.MapPost("/api/author", async (CreateAuthorCommand command, IMediator mediator) =>
            {
                var authorId = await mediator.Send(command);
                return Results.Created($"api/author/{authorId}", authorId);
            });

            application.MapGet("/api/author", async (Guid id, IMediator mediator) =>
            {
                var author = await mediator.Send(new GetAuthorQuery(id));
                return Results.Ok(author);
            });

            return application;
        }
    }   
}
