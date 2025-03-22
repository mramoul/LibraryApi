using MediatR;

namespace LibraryApi.Application.Authors.UpdateAuthor
{
    /// <summary>
    /// Represents the data command required to update an author,
    //  used to trigger the update process through Mediator.
    /// </summary>
    public class UpdateAuthorCommand() : IRequest<UpdateAuthorCommandResult>
    {
        public required Guid Id { get; init; }
        public string FirstName { get; init; } = string.Empty;
        public string LastName { get; init; } = string.Empty;
        public DateTime BirthDate { get; init; }
    }
}
