using LibraryApi.Application.Books.ListBook._DTO;
using LibraryApi.Domain.Entities;

namespace LibraryApi.Application.Books.ListBook._Mappers
{
    /// <summary>
    /// Defines a mapper to convert an <see cref="Author"/> into an <see cref="AuthorModel"/>.
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
            };
        }
    }
}
