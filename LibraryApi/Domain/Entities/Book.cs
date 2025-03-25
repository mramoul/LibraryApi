using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApi.Domain.Entities;

public class Book: Entity
{
    public string Title { get; set; } = string.Empty;
    public string ISBN { get; set; } = string.Empty;
    public DateOnly PublishedDate { get; set; }

    [ForeignKey("AuthorId")]
    public required Author Author { get; set; }

    public void Update(Book newBook)
    {
        Title = newBook.Title;
        ISBN = newBook.ISBN;
        PublishedDate = newBook.PublishedDate;
        Author = newBook.Author;
    }
}
