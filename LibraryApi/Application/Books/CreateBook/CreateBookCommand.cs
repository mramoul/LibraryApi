using MediatR;

namespace LibraryApi.Application.Books.CreateBook
{
    /// <summary>
    /// Represents the data command required to create a new book,
    //  used to trigger the creation process through Mediator.
    /// </summary>
    public class CreateBookCommand : IRequest<CreateBookCommandResult>
    {
        public string Title { get; init; } = string.Empty;
        public string ISBN { get; init; } = string.Empty;
        public DateOnly PublishedDate { get; init; }
        public required Guid AuthorId {get; init;}
    }
}
