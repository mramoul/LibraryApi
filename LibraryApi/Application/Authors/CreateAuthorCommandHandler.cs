using LibraryApi.Infrastructure;
using MediatR;

namespace LibraryApi.Application.Authors
{
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
