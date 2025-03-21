using LibraryApi.Domain.Entities;
namespace LibraryApi.Application.Authors
{
    /// <summary>
    /// Defines a mapper to convert a <see cref="CreateAuthorCommand"/> into an <see cref="Author"/> entity.
    /// </summary>
    public interface ICreateAuthorCommandMapper
    {
        public Author Map(CreateAuthorCommand source);        
    }

    /// <inheritdoc />
    public class CreateAuthorCommandMapper : ICreateAuthorCommandMapper
    {
        public Author Map(CreateAuthorCommand source)
        {
            return new Author()
            {
                FirstName = source.FirstName,
                LastName = source.LastName,
                BirthDate = source.BirthDate
            };
        }
    }
}
