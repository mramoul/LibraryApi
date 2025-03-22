using LibraryApi.Domain.Entities;
namespace LibraryApi.Application.Authors.UpdateAuthor
{
    /// <summary>
    /// Defines a mapper to convert an <see cref="UpdateAuthorCommand"/> into an <see cref="Author"/> entity.
    /// </summary>
    public interface IUpdateAuthorCommandMapper
    {
        public Author Map(UpdateAuthorCommand source);        
    }

    /// <inheritdoc />
    public class UpdateAuthorCommandMapper : IUpdateAuthorCommandMapper
    {
        public Author Map(UpdateAuthorCommand source)
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
