using LibraryApi.Domain;
using LibraryApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Infrastructure.DataBaseContext
{
    /// <summary>
    /// Defines the ApplicationDbContext class that handles database operations for the doamin entities, 
    /// </summary>
    /// <param name="options">DataBase's credential</param>
    public interface IApplicationDbContext
    {
        DbSet<Author> Authors { get; set; }
        DbSet<Book> Books { get; set; }

        /// <summary>
        /// DbContext save changes operation async.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>Save's result</returns>
        Task<int> SaveAsync(CancellationToken cancellationToken);

        /// <summary>
        /// DbContext Add entity operation async.
        /// </summary>
        /// <typeparam name="TEntity">The domain entity type</typeparam>
        /// <param name="entity">The entity to add</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>Addition's result</returns>
        Task AppendAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : Entity;

        /// <summary>
        /// DbContext Update entity operation.
        /// </summary>
        /// <typeparam name="TEntity">The domain entity type</typeparam>
        /// <param name="entity">The entity to update</param>
        void Patch<TEntity>(TEntity entity) where TEntity : Entity;

        /// <summary>
        /// DbContext Delete entity operation.
        /// </summary>
        /// <typeparam name="TEntity">The domain entity type</typeparam>
        /// <param name="entity">The entity to delete</param>
        void Delete<TEntity>(TEntity entity) where TEntity : Entity;

        /// <summary>
        /// DbContext find entity operation.
        /// </summary>
        /// <typeparam name="TEntity">The domain entity type</typeparam>
        /// <param name="id">The entity's ID</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The entity</returns>
        Task<TEntity?> RetrieveAsync<TEntity>(Guid id, CancellationToken cancellationToken = default) where TEntity : Entity;

        /// <summary>
        /// DbContext list entity operation.
        /// </summary>
        /// <typeparam name="TEntity">The domain entity type</typeparam>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        Task<List<TEntity>> ListAsync<TEntity>(CancellationToken cancellationToken = default) where TEntity : Entity;
    }

    /// <inheritdoc />  
    public partial class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options), IApplicationDbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        /// <inheritdoc />  
        public Task<int> SaveAsync(CancellationToken cancellationToken)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        /// <inheritdoc />  
        public void Delete<TEntity>(TEntity entity) where TEntity : Entity
        {
            Set<TEntity>().Remove(entity);
        }

        /// <inheritdoc />  
        public async Task AppendAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : Entity
        {
            await Set<TEntity>().AddAsync(entity, cancellationToken);
        }

         /// <inheritdoc />  
        public async Task<TEntity?> RetrieveAsync<TEntity>(Guid id, CancellationToken cancellationToken = default) where TEntity : Entity
        {
            return await Set<TEntity>().FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        /// <inheritdoc />  
        public async Task<List<TEntity>> ListAsync<TEntity>(CancellationToken cancellationToken = default) where TEntity : Entity
        {
            return await Set<TEntity>().ToListAsync(cancellationToken);
        }

        /// <inheritdoc />  
        public void Patch<TEntity>(TEntity entity) where TEntity : Entity
        {
            Set<TEntity>().Update(entity);
        }
    }
}
