namespace LibraryApi.Application.Authors.UpdateAuthor
{
    /// <summary>
    /// Defines a record to return the result of <see cref="UpdateAuthorCommand"/>, containing the updated author's unique `Id`.
    /// </summary>
    /// <param name="Id">Id of the entity</param>
    public record UpdateAuthorCommandResult(Guid Id);
}
