namespace LibraryApi.Application.Books.CreateBook
{
    /// <summary>
    /// Defines a record to return the result of <see cref="CreateBookCommand"/>, containing the new book's unique `Id`.
    /// </summary>
    /// <param name="Id">Id of the entity</param>
    public record CreateBookCommandResult(Guid Id);
}
