using LibraryApi.Application.Errors;
using LibraryApi.Application.Services.Authors;
using LibraryApi.Infrastructure.DataBaseContext;
using MediatR;

namespace LibraryApi.Application.Authors.DeleteAuthor
{
    /// <summary>
    /// Handles the <see cref="DeleteAuthorCommand"/>, returns the result's message.
    /// </summary>
    /// <param name="authorServices">Service to retrieve data from the Db Context</param>
    public class DeleteAuthorCommandHandler(IApplicationDbContext context, IAuthorServices authorServices) : IRequestHandler<DeleteAuthorCommand, DeleteAuthorCommandResult>
    {
        public async Task<DeleteAuthorCommandResult> Handle(DeleteAuthorCommand command, CancellationToken cancellationToken)
        {
            var author = await authorServices.GetByIdAsync(command.Id, cancellationToken);

            if(author is null)
                throw new NotFoundError($"Author with ID {command.Id} was not found.");
                
            context.Delete(author);
            await context.SaveAsync(cancellationToken);

            return new DeleteAuthorCommandResult($"Author with ID {command.Id} has been successfully deleted.");
        }
    }
}
