namespace LibraryApi.Application.Loans.GetLoan._DTO;

public class BookModel
{
    public required Guid Id { get; init; }
    public string Title { get; init; } = string.Empty;
    public required AuthorModel Author {get; init; }
}
