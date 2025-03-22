using LibraryApi.Application.Errors;
using LibraryApi.Application.Services.Authors;
using LibraryApi.Infrastructure.DataBaseContext;
using MediatR;

namespace LibraryApi.Application.Authors.UpdateAuthor
{
    /// <summary>
    /// Handles the <see cref="UpdateAuthorCommand"/>, returns the result with the updated author's ID.
    /// </summary>
    /// <param name="context">Db Context</param>
    /// <param name="authorServices">Service to retrieve data from the Db Context</param>
    /// <param name="mapper">Maps the DB source data to the result representation</param>
    public class CreateAuthorCommandHandler(IApplicationDbContext context, IAuthorServices authorServices, IUpdateAuthorCommandMapper mapper) : IRequestHandler<UpdateAuthorCommand, UpdateAuthorCommandResult>
    {
        public async Task<UpdateAuthorCommandResult> Handle(UpdateAuthorCommand command, CancellationToken cancellationToken)
        {
            var author = await authorServices.GetByIdAsync(command.Id, cancellationToken);

            if(author is null)
                throw new NotFoundError($"Author with ID {command.Id} was not found.");

            var newAuthor = mapper.Map(command);
            author.Update(newAuthor);

            await context.SaveAsync(cancellationToken);

            return new UpdateAuthorCommandResult(author.Id);
        }
    }
}
