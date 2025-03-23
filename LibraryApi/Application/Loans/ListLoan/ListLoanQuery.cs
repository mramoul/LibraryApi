using MediatR;

namespace LibraryApi.Application.Loans.ListLoan
{
    /// <summary>
    /// Represents the query required to get list of loans,
    //  used to trigger the retrieve process through Mediator.
    /// </summary>
    public record ListLoanQuery : IRequest<ListLoanQueryResult>;
}
