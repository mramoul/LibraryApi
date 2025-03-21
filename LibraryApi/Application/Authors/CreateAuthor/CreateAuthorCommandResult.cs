namespace LibraryApi.Application.Authors.CreateAuthor
{
    /// <summary>
    /// Defines a record to return the result of <see cref="CreateAuthorCommand"/>, containing the new author's unique `Id`.
    /// </summary>
    /// <param name="Id">Id of the entity</param>
    public record CreateAuthorCommandResult(Guid Id);
}
