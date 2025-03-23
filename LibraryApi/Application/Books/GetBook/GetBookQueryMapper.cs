using LibraryApi.Application.Books._Mappers;
using LibraryApi.Domain.Entities;

namespace LibraryApi.Application.Books.GetBook
{
    /// <summary>
    /// Defines a mapper to convert an <see cref="Book"/> into a <see cref="GetBookQueryResult"/> entity.
    /// </summary>
    public interface IGetBookQueryMapper
    {
        public GetBookQueryResult Map(Book source);        
    }

    /// <inheritdoc />
    public class GetBookQueryMapper(IAuthorMapper authorMapper) : IGetBookQueryMapper
    {
        public GetBookQueryResult Map(Book source)
        {
            return new GetBookQueryResult(source.Id)
            {
                Title = source.Title,
                ISBN = source.ISBN,
                PublishedDate = source.PublishedDate,
                Author = authorMapper.Map(source.Author)
            };
        }
    }
}
