using LibraryApi.Domain;

namespace LibraryApi.Application.Services
{
    public interface IBaseServices<TEntity> where TEntity: Entity
    {
        /// <summary>
        /// Retrieve entities from the database by there unique Id.
        /// </summary>
        /// <param name="id">The entity's unique Id</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The desired entity</returns>
        Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}