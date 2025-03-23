using LibraryApi.Domain.Entities;
using LibraryApi.Infrastructure.DataBaseContext;

namespace LibraryApi.Application.Services.Loans
{
    /// <summary>
    /// Defines the service for handling Loan entities.
    /// </summary>
    public interface ILoanServices : IBaseServices<Loan>
    {
        public Task<Book?> GetBookByIdAsync(Guid id, CancellationToken cancellationToken);
    }

    /// <inheritdoc />  
       public class LoanServices(IApplicationDbContext dbContext) : BaseServices<Loan>(dbContext), ILoanServices
    {
        private readonly IApplicationDbContext _dbContext = dbContext;

        Task<Book?> ILoanServices.GetBookByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = _dbContext.RetrieveAsync<Book>(id, cancellationToken);
            return entity;
        }
    }
}