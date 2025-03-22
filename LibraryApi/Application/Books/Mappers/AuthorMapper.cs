using LibraryApi.Application.Books.DTO;
using LibraryApi.Domain.Entities;

namespace LibraryApi.Application.Books.Mappers
{
    /// <summary>
    /// Defines a mapper to convert an <see cref="Author"/> into a <see cref="GetAuthorQueryResult"/> entity.
    /// </summary>
    public interface IAuthorMapper
    {
        public AuthorModel Map(Author source);        
    }

    /// <inheritdoc />
    public class AuthorMapper : IAuthorMapper
    {
        public AuthorModel Map(Author source)
        {
            return new AuthorModel()
            {
                FirstName = source.FirstName,
                LastName = source.LastName,
                BirthDate = source.BirthDate
            };
        }
    }
}
