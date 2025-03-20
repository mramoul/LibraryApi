namespace LibraryApi.Domain.Entities;

public class Book: Entity
{
    public string Title { get; set; } = string.Empty;
    public string ISBN { get; set; } = string.Empty;
    public DateTime PublishedDate { get; set; }
    public required Author Author { get; set; }
}
