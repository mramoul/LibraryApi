using System.Collections.Immutable;
using LibraryApi.Application.Books.Listbook._DTO;

namespace LibraryApi.Application.Books.ListBook
{
    /// <summary>
    /// Defines a record to return the result of <see cref="ListBookQuery"/>, containing the list of books data.
    /// </summary>
    public record ListBookQueryResult()
    {
        public required ImmutableList<BookModel> ListBooks {get; init;}
    }
}
