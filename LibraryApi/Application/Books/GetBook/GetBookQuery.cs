using MediatR;

namespace LibraryApi.Application.Books.GetBook
{
    /// <summary>
    /// Represents the query required to get a book,
    //  used to trigger the author retrieve process through Mediator.
    /// </summary>
    public record GetBookQuery(Guid Id) : IRequest<GetBookQueryResult>;
}
