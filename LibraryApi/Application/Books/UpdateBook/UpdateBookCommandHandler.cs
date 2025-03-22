using LibraryApi.Application.Errors;
using LibraryApi.Application.Services.Authors;
using LibraryApi.Domain.Entities;
using LibraryApi.Infrastructure.DataBaseContext;
using MediatR;

namespace LibraryApi.Application.Books.UpdateBook
{
    /// <summary>
    /// Handles the <see cref="UpdateBookCommand"/>, returns the result with the updated book's ID.
    /// </summary>
    /// <param name="context">Db Context</param>
    /// <param name="bookServices">Service to retrieve data from the Db Context</param>
    /// <param name="mapper">Maps the DB source data to the result representation</param>
    public class CreateAuthorCommandHandler(IApplicationDbContext context, IBookServices bookServices, IUpdateBookCommandMapper mapper) : IRequestHandler<UpdateBookCommand, UpdateBookCommandResult>
    {
        public async Task<UpdateBookCommandResult> Handle(UpdateBookCommand command, CancellationToken cancellationToken)
        {
            var book = await bookServices.GetByIdAsync(command.Id, cancellationToken);

            if(book is null)
                throw new NotFoundError($"{nameof(Book)} with ID {command.Id} was not found.");

            var author = book.Author;

            if(command.AuthorId is not null)
            {
               author = await TryGetAuthor((Guid)command.AuthorId, cancellationToken);
            }

            var newBook = mapper.Map(command, author);
            book.Update(newBook);

            await context.SaveAsync(cancellationToken);

            return new UpdateBookCommandResult(book.Id);
        }

        private async Task<Author> TryGetAuthor(Guid authorId, CancellationToken cancellationToken)
        {
            var author = await bookServices.GetAuthorByIdAsync(authorId, cancellationToken);

                if(author is null)
                    throw new NotFoundError($"{nameof(Author)} with ID {authorId} was not found.");

            return author;
        }
    }
}
