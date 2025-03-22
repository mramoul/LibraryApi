using MediatR;

namespace LibraryApi.Application.Authors.ListAuthor
{
    /// <summary>
    /// Represents the query required to get list of authors,
    //  used to trigger the retrieve process through Mediator.
    /// </summary>
    public record ListAuthorQuery : IRequest<ListAuthorQueryResult>;
}
