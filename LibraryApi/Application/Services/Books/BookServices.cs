using LibraryApi.Domain.Entities;
using LibraryApi.Infrastructure.DataBaseContext;

namespace LibraryApi.Application.Services.Authors
{
    /// <summary>
    /// Defines the service for handling Book entities.
    /// </summary>
    public interface IBookServices : IBaseServices<Book>
    {
        public Task<Author?> GetAuthorByIdAsync(Guid id, CancellationToken cancellationToken);
    }

    /// <inheritdoc />  
       public class BookServices(IApplicationDbContext dbContext) : BaseServices<Book>(dbContext), IBookServices
    {
        private readonly IApplicationDbContext _dbContext = dbContext;

        Task<Author?> IBookServices.GetAuthorByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = _dbContext.RetrieveAsync<Author>(id, cancellationToken);
            return entity;
        }
    }
}