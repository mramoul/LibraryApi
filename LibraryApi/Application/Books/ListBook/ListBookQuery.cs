using MediatR;

namespace LibraryApi.Application.Books.ListBook
{
    /// <summary>
    /// Represents the query required to get list of books,
    //  used to trigger the retrieve process through Mediator.
    /// </summary>
    public record ListBookQuery : IRequest<ListBookQueryResult>;
}
