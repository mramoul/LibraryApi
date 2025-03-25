using System.Collections.Immutable;
using LibraryApi.Application.Books.GetBook._DTO;
using LibraryApi.Application.Books.GetBook._Mappers;
using LibraryApi.Domain.Entities;

namespace LibraryApi.Application.Books.GetBook
{
    /// <summary>
    /// Defines a mapper to convert a <see cref="Book"/> into a <see cref="GetBookQueryResult"/>.
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
                Author = authorMapper.Map(source.Author),
                Loans = source.Loans?.Select(MapItem).ToImmutableList()
            };
        }

        private static LoanModel MapItem(Loan source)
        {
            return new LoanModel()
            {
                Id = source.Id,
            };
        }
    }
}
