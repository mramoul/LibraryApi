using LibraryApi.Domain;

namespace LibraryApi.Application.Services
{
    public interface IBaseServices<TEntity> where TEntity: Entity
    {
        Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}