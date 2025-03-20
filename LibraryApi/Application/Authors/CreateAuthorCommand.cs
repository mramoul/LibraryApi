using MediatR;

namespace LibraryApi.Application.Authors
{
    /// <summary>
    /// Represents the data command required to create a new author,
    //  used to trigger the author creation process through Mediator.
    /// </summary>
    public class CreateAuthorCommand : IRequest<CreateAuthorCommandResult>
    {
         public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
    }
}
