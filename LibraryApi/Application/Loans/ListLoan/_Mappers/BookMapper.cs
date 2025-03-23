using LibraryApi.Application.Loans.ListLoan._DTO;
using LibraryApi.Domain.Entities;

namespace LibraryApi.Application.Loans.ListLoan._Mappers
{
    /// <summary>
    /// Defines a mapper to convert a <see cref="Book"/> into a <see cref="BookModel"/>.
    /// </summary>
    public interface IBookMapper
    {
        public BookModel Map(Book source);        
    }

    /// <inheritdoc />
    public class BookMapper : IBookMapper
    {
        public BookModel Map(Book source)
        {
            return new BookModel()
            {
                Title = source.Title,
            };
        }
    }
}
