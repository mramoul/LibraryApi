using System.Collections.Immutable;
using LibraryApi.Domain.Entities;

namespace LibraryApi.Application.Authors.GetAuthor
{
    /// <summary>
    /// Defines a mapper to convert an <see cref="Author"/> into a <see cref="GetAuthorQueryResult"/>.
    /// </summary>
    public interface IGetAuthorQueryMapper
    {
        public GetAuthorQueryResult Map(Author source);        
    }

    /// <inheritdoc />
    public class GetAuthorQueryMapper : IGetAuthorQueryMapper
    {
        public GetAuthorQueryResult Map(Author source)
        {
            return new GetAuthorQueryResult(source.Id)
            {
                FirstName = source.FirstName,
                LastName = source.LastName,
                BirthDate = source.BirthDate,
                Books = source.Books?.Select(MapItem).ToImmutableList()
            };
        }

        private static BookModel MapItem(Book source)
        {
            return new BookModel()
            {
                Id = source.Id,
                Title = source.Title
            };
        }
    }
}
