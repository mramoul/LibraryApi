using MediatR;

namespace LibraryApi.Application.Authors.DeleteAuthor
{
    /// <summary>
    /// Represents the command required to delete an author,
    //  used to trigger the deletion process through Mediator.
    /// </summary>
    public record DeleteAuthorCommand(Guid Id) : IRequest<DeleteAuthorCommandResult>;
}
