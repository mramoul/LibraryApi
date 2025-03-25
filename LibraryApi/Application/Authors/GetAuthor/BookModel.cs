namespace LibraryApi.Application.Authors.GetAuthor;

public class BookModel
{
    public required Guid Id { get; init; }
    public string Title { get; init; } = string.Empty;
}
