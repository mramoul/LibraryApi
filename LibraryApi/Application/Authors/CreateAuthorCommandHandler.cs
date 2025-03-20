using LibraryApi.Infrastructure.DataBaseContext;
using MediatR;

namespace LibraryApi.Application.Authors
{
    /// <summary>
    /// Handles the <see cref="CreateAuthorCommand"/>, returns the result with the created author's ID.
    /// </summary>
    /// <param name="context">Db Context</param>
    /// <param name="mapper">Maps the command data to the entity representation</param>
    public class CreateAAuthorCommandHandler(IApplicationDbContext context, ICreateAuthorCommandMapper mapper) : IRequestHandler<CreateAuthorCommand, CreateAuthorCommandResult>
    {
        private readonly IApplicationDbContext _context = context;

        public async Task<CreateAuthorCommandResult> Handle(CreateAuthorCommand command, CancellationToken cancellationToken)
        {
            var author = mapper.Map(command);

            await _context.AppendAsync(author, cancellationToken);
            await _context.SaveAsync(cancellationToken);

            return new CreateAuthorCommandResult(author.Id);
        }
    }
}
