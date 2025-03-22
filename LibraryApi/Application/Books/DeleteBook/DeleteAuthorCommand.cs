using MediatR;

namespace LibraryApi.Application.Books.DeleteBook
{
    /// <summary>
    /// Represents the command required to delete a book,
    //  used to trigger the deletion process through Mediator.
    /// </summary>
    public record DeleteBookCommand(Guid Id) : IRequest<DeleteBookCommandResult>;
}
