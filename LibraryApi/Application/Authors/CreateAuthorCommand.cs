using MediatR;

namespace LibraryApi.Application.Authors
{
    public class CreateAuthorCommand : IRequest<CreateAuthorCommandResult>
    {
         public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
    }
}
