using LibraryApi.Application.Errors;
using LibraryApi.Application.Services.Loans;
using LibraryApi.Domain.Entities;
using MediatR;

namespace LibraryApi.Application.Loans.GetLoan
{
    /// <summary>
    /// Handles the <see cref="GetLoanQuery"/>, returns the result with the loan's data.
    /// </summary>
    /// <param name="loanServices">Service to retrieve data from the Db Context</param>
    /// <param name="mapper">Maps the DB source data to the result representation</param>
    public class GetLoanQueryHandler(ILoanServices loanServices, IGetLoanQueryMapper mapper) : IRequestHandler<GetLoanQuery, GetLoanQueryResult>
    {
        public async Task<GetLoanQueryResult> Handle(GetLoanQuery query, CancellationToken cancellationToken)
        {
            var book = await loanServices.GetByIdAsync(query.Id, cancellationToken);

            if(book is null)
                throw new NotFoundError($"{nameof(Book)} with ID {query.Id} was not found.");
                
            var result = mapper.Map(book);

            return result;
        }
    }
}
