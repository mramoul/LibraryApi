namespace LibraryApi.Application.Authors.GetAuthor
{
    /// <summary>
    /// Defines a record to return the result of <see cref="GetAuthorQuery"/>, containing the author's data.
    /// </summary>
    /// <param name="Id">Id of the entity</param>
    public record GetAuthorQueryResult(Guid Id)
    {
        public string FirstName { get; init; } = string.Empty;
        public string LastName { get; init; } = string.Empty;
        public DateTime BirthDate { get; init; }
    }
}
