using LibraryApi.Application.Loans.GetLoan._DTO;
using LibraryApi.Domain.Entities;

namespace LibraryApi.Application.Loans.GetLoan._Mappers
{
    /// <summary>
    /// Defines a mapper to convert a <see cref="Book"/> into a <see cref="BookModel"/> entity.
    /// </summary>
    public interface IBookMapper
    {
        public BookModel Map(Book source);        
    }

    /// <inheritdoc />
    public class BookMapper(IAuthorMapper authorMapper) : IBookMapper
    {
        public BookModel Map(Book source)
        {
            return new BookModel()
            {
                Id = source.Id,
                Title = source.Title,
                Author = authorMapper.Map(source.Author)
            };
        }
    }
}
