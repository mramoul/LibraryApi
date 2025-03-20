namespace LibraryApi.Application.Authors
{
    /// <summary>
    /// Defines a record to return the result of <see cref="CreateAuthorCommand"/>, containing the new author's unique `Id`.
    /// </summary>
    /// <param name="Id"></param>
    public record CreateAuthorCommandResult(Guid Id);
}
