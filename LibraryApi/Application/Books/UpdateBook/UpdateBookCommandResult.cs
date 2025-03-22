namespace LibraryApi.Application.Books.UpdateBook
{
    /// <summary>
    /// Defines a record to return the result of <see cref="UpdateBookCommand"/>, containing the updated book's unique `Id`.
    /// </summary>
    /// <param name="Id">Id of the entity</param>
    public record UpdateBookCommandResult(Guid Id);
}
