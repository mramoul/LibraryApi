using System.Collections.Immutable;
using LibraryApi.Application.Authors.ListAuthor.DTO;
using LibraryApi.Domain.Entities;

namespace LibraryApi.Application.Authors.ListAuthor
{
    /// <summary>
    /// Defines a mapper to convert a list of <see cref="Author"/> into a <see cref="ListAuthorQueryResult"/>.
    /// </summary>
    public interface IListAuthorQueryMapper
    {
        public ListAuthorQueryResult Map(List<Author> source);        
    }

    /// <inheritdoc />
    public class ListAuthorQueryMapper : IListAuthorQueryMapper
    {
        public ListAuthorQueryResult Map(List<Author> source)
        {
            
            return new ListAuthorQueryResult()
            {
              ListAuthors = source.Select(x => MapItem(x)).ToImmutableList()
            };
        }

        private static AuthorModel MapItem(Author source)
        {
            return new AuthorModel()
            {
                Id = source.Id,
                FirstName = source.FirstName,
                LastName = source.LastName,
                BirthDate = source.BirthDate
            };
        }
    }

}
