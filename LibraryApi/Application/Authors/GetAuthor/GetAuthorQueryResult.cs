namespace LibraryApi.Application.Authors
{
    /// <summary>
    /// Defines a record to return the result of <see cref="GetAuthorQuery"/>, containing the new author's unique `Id`.
    /// </summary>
    /// <param name="Id">Id of the entity</param>
    public record GetAuthorQueryResult(Guid Id)
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
    }
}
