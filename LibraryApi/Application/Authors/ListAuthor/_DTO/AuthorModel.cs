namespace LibraryApi.Application.Authors.ListAuthor.DTO;

public class AuthorModel
{
    public required Guid Id { get; init; }
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public DateOnly BirthDate { get; init; }
}
