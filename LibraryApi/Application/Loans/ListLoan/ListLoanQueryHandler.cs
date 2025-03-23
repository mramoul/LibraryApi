using LibraryApi.Application.Errors;
using LibraryApi.Application.Loans.ListLoan;
using LibraryApi.Application.Services.Loans;
using LibraryApi.Domain.Entities;
using MediatR;

namespace LibraryApi.Application.Books.ListBook
{
    /// <summary>
    /// Handles the <see cref="ListLoanQuery"/>, returns the result with the list of loans data.
    /// </summary>
    /// <param name="loanServices">Service to retrieve data from the Db Context</param>
    /// <param name="mapper">Maps the DB source data to the result representation</param>
    public class ListLoanQueryHandler(ILoanServices loanServices, IListLoanQueryMapper mapper) : IRequestHandler<ListLoanQuery, ListLoanQueryResult>
    {
        public async Task<ListLoanQueryResult> Handle(ListLoanQuery query, CancellationToken cancellationToken)
        {
            var loans = await loanServices.GetListdAsync(cancellationToken);

            if(loans is null)
                throw new NotFoundError($"No {nameof(Loan)}s were found.");
                
            var result = mapper.Map(loans);

            return result;
        }
    }
}
