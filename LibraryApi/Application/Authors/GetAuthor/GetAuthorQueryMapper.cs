using LibraryApi.Domain.Entities;
namespace LibraryApi.Application.Authors
{
    /// <summary>
    /// Defines a mapper to convert a <see cref="GetAuthorQuery"/> into an <see cref="Author"/> entity.
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
                BirthDate = source.BirthDate
            };
        }
    }
}
