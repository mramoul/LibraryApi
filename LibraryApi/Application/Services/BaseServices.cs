using LibraryApi.Domain;
using LibraryApi.Infrastructure.DataBaseContext;

namespace LibraryApi.Application.Services
{
    public class BaseServices<TEntity>(IApplicationDbContext dbContext): IBaseServices<TEntity> where TEntity: Entity
    {
        public Task<TEntity?> GetListdAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        Task<TEntity?> IBaseServices<TEntity>.GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = dbContext.RetrieveAsync<TEntity>(id, cancellationToken);
            return entity;
        }

        /// <inheritdoc />
        Task<List<TEntity>> IBaseServices<TEntity>.GetListdAsync(CancellationToken cancellationToken)
        {
            return dbContext.ListAsync<TEntity>(cancellationToken);
        }
    }
}