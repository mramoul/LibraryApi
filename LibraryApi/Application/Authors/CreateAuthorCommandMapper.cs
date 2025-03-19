using LibraryApi.Domain.Entities;
namespace LibraryApi.Application.Authors
{
    public interface ICreateAuthorCommandMapper
    {
        public Author Map(CreateAuthorCommand source);        
    }

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
