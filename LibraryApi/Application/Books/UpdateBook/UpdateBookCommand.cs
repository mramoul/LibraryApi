using MediatR;

namespace LibraryApi.Application.Books.UpdateBook
{
    /// <summary>
    /// Represents the data command required to update a book,
    //  used to trigger the update process through Mediator.
    /// </summary>
    public class UpdateBookCommand() : IRequest<UpdateBookCommandResult>
    {
        public required Guid Id { get; init; }
        public string Title { get; init; } = string.Empty;
        public string ISBN { get; init; } = string.Empty;
        public DateOnly PublishedDate { get; init; }
        public Guid? AuthorId {get; init;}
    }
}
