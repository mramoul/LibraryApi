using LibraryApi.Infrastructure.DataBaseContext;
using MediatR;

namespace LibraryApi.Application.Authors.CreateAuthor
{
    /// <summary>
    /// Handles the <see cref="CreateAuthorCommand"/>, returns the result with the created author's ID.
    /// </summary>
    /// <param name="context">Db Context</param>
    /// <param name="mapper">Maps the DB source data to the result representation</param>
    public class CreateAuthorCommandHandler(IApplicationDbContext context, ICreateAuthorCommandMapper mapper) : IRequestHandler<CreateAuthorCommand, CreateAuthorCommandResult>
    {
        public async Task<CreateAuthorCommandResult> Handle(CreateAuthorCommand command, CancellationToken cancellationToken)
        {
            var author = mapper.Map(command);

            await context.AppendAsync(author, cancellationToken);
            await context.SaveAsync(cancellationToken);

            return new CreateAuthorCommandResult(author.Id);
        }
    }
}
