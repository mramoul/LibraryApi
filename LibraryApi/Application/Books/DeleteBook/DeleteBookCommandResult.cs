namespace LibraryApi.Application.Books.DeleteBook
{
    /// <summary>
    /// Defines a record to return the result of <see cref="DeleteBookCommand"/>.
    /// </summary>
    /// <param name="Message">Message to return</param>
    public record DeleteBookCommandResult(string Message);
}
