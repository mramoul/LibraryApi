using MediatR;

namespace LibraryApi.Application.Authors
{
    /// <summary>
    /// Represents the data command required to create a new author,
    //  used to trigger the author creation process through Mediator.
    /// </summary>
    public record GetAuthorQuery(Guid Id) : IRequest<GetAuthorQueryResult>;
}
