using LibraryApi.Domain;
using LibraryApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Infrastructure.DataBaseContext
{
    /// <summary>
    /// Defines the ApplicationDbContext class that handles database operations for the doamin entities, 
    //  including saving and appending new entities asynchronously.
    /// </summary>
    /// <param name="options">DataBase's credential</param>
    public interface IApplicationDbContext
    {
        DbSet<Author> Authors { get; set; }
        Task<int> SaveAsync(CancellationToken cancellationToken);
        Task AppendAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : Entity;
        Task<TEntity?> RetrieveAsync<TEntity>(Guid id, CancellationToken cancellationToken = default) where TEntity : Entity;
    }

    /// <inheritdoc />  
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options), IApplicationDbContext
    {
        public DbSet<Author> Authors { get; set; }

        public Task<int> SaveAsync(CancellationToken cancellationToken)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        public async Task AppendAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : Entity
        {
            await Set<TEntity>().AddAsync(entity, cancellationToken);
        }

        public async Task<TEntity?> RetrieveAsync<TEntity>(Guid id, CancellationToken cancellationToken = default) where TEntity : Entity
        {
            return await Set<TEntity>().FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }
    }
}
