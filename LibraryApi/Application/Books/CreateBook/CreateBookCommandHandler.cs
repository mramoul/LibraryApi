using LibraryApi.Application.Errors;
using LibraryApi.Application.Services.Books;
using LibraryApi.Domain.Entities;
using LibraryApi.Infrastructure.DataBaseContext;
using MediatR;

namespace LibraryApi.Application.Books.CreateBook
{
    /// <summary>
    /// Handles the <see cref="CreateBookCommand"/>, returns the result with the created book's ID.
    /// </summary>
    /// <param name="context">Db Context</param>
    /// <param name="bookServices">Service to retrieve data from the Db Context</param>
    /// <param name="mapper">Maps the DB source data to the result representation</param>
    public class CreateBookCommandHandler(IApplicationDbContext context, IBookServices bookServices, ICreateBookCommandMapper mapper) : IRequestHandler<CreateBookCommand, CreateBookCommandResult>
    {
        public async Task<CreateBookCommandResult> Handle(CreateBookCommand command, CancellationToken cancellationToken)
        {
            var author = bookServices.GetAuthorByIdAsync(command.AuthorId, cancellationToken);

            if(author.Result is null)
                throw new NotFoundError($"{nameof(Author)} with ID {command.AuthorId} was not found.");

            var book = mapper.Map(command, author.Result);

            await context.AppendAsync(book, cancellationToken);
            await context.SaveAsync(cancellationToken);

            return new CreateBookCommandResult(book.Id);
        }
    }
}
