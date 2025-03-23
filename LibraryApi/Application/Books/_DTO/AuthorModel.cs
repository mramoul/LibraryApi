namespace LibraryApi.Application.Books._DTO;

public class AuthorModel
{
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public DateOnly BirthDate { get; init; }
}
