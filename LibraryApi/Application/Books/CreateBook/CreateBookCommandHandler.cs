using LibraryApi.Application.Books.CreateBook;
using LibraryApi.Application.Errors;
using LibraryApi.Application.Services.Authors;
using LibraryApi.Infrastructure.DataBaseContext;
using MediatR;

namespace LibraryApi.Application.Books.CreateBook
{
    /// <summary>
    /// Handles the <see cref="CreateBookCommand"/>, returns the result with the created book's ID.
    /// </summary>
    /// <param name="context">Db Context</param>
    /// <param name="mapper">Maps the DB source data to the result representation</param>
    public class CreateBookCommandHandler(IApplicationDbContext context, IAuthorServices authorServices, ICreateBookCommandMapper mapper) : IRequestHandler<CreateBookCommand, CreateBookCommandResult>
    {
        public async Task<CreateBookCommandResult> Handle(CreateBookCommand command, CancellationToken cancellationToken)
        {
            var author = authorServices.GetByIdAsync(command.AuthorId, cancellationToken);

            if(author.Result is null)
                throw new NotFoundError($"Author with ID {command.AuthorId} was not found.");

            var book = mapper.Map(command, author.Result);

            await context.AppendAsync(book, cancellationToken);
            await context.SaveAsync(cancellationToken);

            return new CreateBookCommandResult(book.Id);
        }
    }
}
