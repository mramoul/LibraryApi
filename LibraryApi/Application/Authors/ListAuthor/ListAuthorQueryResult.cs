using System.Collections.Immutable;
using LibraryApi.Application.Authors.ListAuthor._DTO;

namespace LibraryApi.Application.Authors.ListAuthor
{
    /// <summary>
    /// Defines a record to return the result of <see cref="ListAuthorQuery"/>, containing the list of authors data.
    /// </summary>
    public record ListAuthorQueryResult()
    {
        public required ImmutableList<AuthorModel> ListAuthors {get; init;}
    }
}
