namespace LibraryApi.Application.Authors.DeleteAuthor
{
    /// <summary>
    /// Defines a record to return the result of <see cref="DeleteAuthorCommand"/>.
    /// </summary>
    /// <param name="Message">Message to return</param>
    public record DeleteAuthorCommandResult(string Message);
}
