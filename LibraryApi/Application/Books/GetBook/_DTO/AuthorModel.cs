namespace LibraryApi.Application.Books.GetBook._DTO;

public class AuthorModel
{
    public Guid Id {get; init;}
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public DateOnly BirthDate { get; init; }
}
