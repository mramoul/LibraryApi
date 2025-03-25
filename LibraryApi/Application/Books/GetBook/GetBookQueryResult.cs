using System.Collections.Immutable;
using LibraryApi.Application.Books.GetBook._DTO;

namespace LibraryApi.Application.Books.GetBook
{
    /// <summary>
    /// Defines a record to return the result of <see cref="GetBookQuery"/>, containing the book's data.
    /// </summary>
    /// <param name="Id">Id of the entity</param>
    public record GetBookQueryResult(Guid Id)
    {
        public string Title { get; init; } = string.Empty;
        public string ISBN { get; init; } = string.Empty;
        public DateOnly PublishedDate { get; init; }
        public required AuthorModel Author { get; init; }
        public ImmutableList<LoanModel>? Loans {get; init;}
    }
}
