using LibraryApi.Application.Loans.GetLoan._DTO;

namespace LibraryApi.Application.Loans.GetLoan
{
    /// <summary>
    /// Defines a record to return the result of <see cref="GetLoanQuery"/>, containing the loan's data.
    /// </summary>
    /// <param name="Id">Id of the entity</param>
    public record GetLoanQueryResult(Guid Id)
    {
        public required BookModel Book { get; init; }
        public DateTime BorrowDate { get; init; }
        public DateOnly ReturnDate { get; init; }
    }
}
