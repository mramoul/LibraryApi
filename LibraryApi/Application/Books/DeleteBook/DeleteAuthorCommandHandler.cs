using LibraryApi.Application.Errors;
using LibraryApi.Application.Services.Books;
using LibraryApi.Domain.Entities;
using LibraryApi.Infrastructure.DataBaseContext;
using MediatR;

namespace LibraryApi.Application.Books.DeleteBook
{
    /// <summary>
    /// Handles the <see cref="DeleteBookCommand"/>, returns the result's message.
    /// </summary>
    /// <param name="context">Db Context</param>
    /// <param name="bookServices">Service to retrieve data from the Db Context</param>
    public class DeleteBookCommandHandler(IApplicationDbContext context, IBookServices bookServices) : IRequestHandler<DeleteBookCommand, DeleteBookCommandResult>
    {
        public async Task<DeleteBookCommandResult> Handle(DeleteBookCommand command, CancellationToken cancellationToken)
        {
            var book = await bookServices.GetByIdAsync(command.Id, cancellationToken);

            if(book is null)
                throw new NotFoundError($"{nameof(Book)} with ID {command.Id} was not found.");
                
            context.Delete(book);
            await context.SaveAsync(cancellationToken);

            return new DeleteBookCommandResult($"{nameof(Book)} with ID {command.Id} has been successfully deleted.");
        }
    }
}
