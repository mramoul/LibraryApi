using LibraryApi.Application.Books.ListBook._DTO;

namespace LibraryApi.Application.Books.Listbook._DTO;

public class BookModel
{
    public required Guid Id { get; init; }
    public string Title { get; init; } = string.Empty;
    public required AuthorModel Author { get; set; }
}
