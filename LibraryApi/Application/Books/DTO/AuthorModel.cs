namespace LibraryApi.Application.Books.DTO;

public class AuthorModel
{
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public DateTime BirthDate { get; init; }
}
