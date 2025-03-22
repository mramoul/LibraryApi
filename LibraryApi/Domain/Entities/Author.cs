namespace LibraryApi.Domain.Entities;

public class Author : Entity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }

    public void Update(Author newAuthor)
    {
        FirstName = newAuthor.FirstName;
        LastName = newAuthor.LastName;
        BirthDate = newAuthor.BirthDate;
    }
}
