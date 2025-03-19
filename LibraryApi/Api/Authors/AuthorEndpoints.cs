using LibraryApi.Application.Authors;
using MediatR;

namespace LibraryApi.Api.Authors
{
    public static class AuthorEndpoints{

        public static WebApplication Register(WebApplication application)
        {
            application.MapPost("/api/author", async (CreateAuthorCommand command, IMediator mediator) =>
            {
                var authorId = await mediator.Send(command);
                return Results.Created($"api/author/{authorId}", authorId);
            });

            return application;
        }
    }   
}
