using MediatR;

namespace LibraryApi.Application.Authors.CreateAuthor
{
    /// <summary>
    /// Represents the data command required to create a new author,
    //  used to trigger the creation process through Mediator.
    /// </summary>
    public class CreateAuthorCommand : IRequest<CreateAuthorCommandResult>
    {
        public string FirstName { get; init; } = string.Empty;
        public string LastName { get; init; } = string.Empty;
        public DateOnly BirthDate { get; init; }
    }
}
