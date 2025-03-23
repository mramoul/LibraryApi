using System.Collections.Immutable;
using LibraryApi.Application.Loans.ListLoan._DTO;

namespace LibraryApi.Application.Loans.ListLoan
{
    /// <summary>
    /// Defines a record to return the result of <see cref="ListLoanQuery"/>, containing the list of loans data.
    /// </summary>
    public record ListLoanQueryResult()
    {
        public required ImmutableList<LoanModel> ListBooks {get; init;}
    }
}
