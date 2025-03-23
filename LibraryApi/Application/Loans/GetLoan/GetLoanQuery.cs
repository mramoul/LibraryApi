using MediatR;

namespace LibraryApi.Application.Loans.GetLoan
{
    /// <summary>
    /// Represents the query required to get a loan,
    //  used to trigger the retrieve process through Mediator.
    /// </summary>
    public record GetLoanQuery(Guid Id) : IRequest<GetLoanQueryResult>;
}
