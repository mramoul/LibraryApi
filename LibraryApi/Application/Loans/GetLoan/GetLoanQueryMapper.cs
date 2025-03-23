using LibraryApi.Application.Loans.GetLoan._Mappers;
using LibraryApi.Domain.Entities;

namespace LibraryApi.Application.Loans.GetLoan
{
    /// <summary>
    /// Defines a mapper to convert a <see cref="Loan"/> into a <see cref="GetLoanQueryResult"/>.
    /// </summary>
    public interface IGetLoanQueryMapper
    {
        public GetLoanQueryResult Map(Loan source);        
    }

    /// <inheritdoc />
    public class GetLoanQueryMapper(IBookMapper bookMapper) : IGetLoanQueryMapper
    {
        public GetLoanQueryResult Map(Loan source)
        {
            return new GetLoanQueryResult(source.Id)
            {
                BorrowDate = source.BorrowDate,
                ReturnDate = source.ReturnDate,
                Book = bookMapper.Map(source.Book),
            };
        }
    }
}
