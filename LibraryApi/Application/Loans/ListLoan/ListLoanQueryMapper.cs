using System.Collections.Immutable;
using LibraryApi.Application.Loans.ListLoan._DTO;
using LibraryApi.Application.Loans.ListLoan._Mappers;
using LibraryApi.Domain.Entities;

namespace LibraryApi.Application.Loans.ListLoan
{
    /// <summary>
    /// Defines a mapper to convert a list of <see cref="Loan"/> into a <see cref="ListLoanQueryResult"/>.
    /// </summary>
    public interface IListLoanQueryMapper
    {
        public ListLoanQueryResult Map(List<Loan> source);        
    }

    /// <inheritdoc />
    public class ListLoanQueryMapper(IBookMapper bookMapper) : IListLoanQueryMapper
    {
        public ListLoanQueryResult Map(List<Loan> source)
        {
            
            return new ListLoanQueryResult()
            {
              ListBooks = source.Select(x => MapItem(x)).ToImmutableList()
            };
        }

        private LoanModel MapItem(Loan source)
        {
            return new LoanModel()
            {
                Id = source.Id,
                BorrowDate = source.BorrowDate,
                ReturnDate = source.ReturnDate,
                Book = bookMapper.Map(source.Book)
            };
        }
    }
}
