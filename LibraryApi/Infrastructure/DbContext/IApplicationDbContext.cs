using LibraryApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Infrastructure
{
    public interface IApplicationDbContext
    {
        DbSet<Author> Authors { get; set; }
        Task<int> SaveAsync(CancellationToken cancellationToken);
        Task AppendAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : class;
    }
}
