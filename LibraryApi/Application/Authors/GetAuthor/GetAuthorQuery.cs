using MediatR;

namespace LibraryApi.Application.Authors.GetAuthor
{
    /// <summary>
    /// Represents the query required to get an author,
    //  used to trigger the author retrieve process through Mediator.
    /// </summary>
    public record GetAuthorQuery(Guid Id) : IRequest<GetAuthorQueryResult>;
}
