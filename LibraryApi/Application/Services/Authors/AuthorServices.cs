using LibraryApi.Domain.Entities;
using LibraryApi.Infrastructure.DataBaseContext;

namespace LibraryApi.Application.Services.Authors
{
    /// <summary>
    /// Defines the service for handling Author entities.
    /// </summary>
    public interface IAuthorServices : IBaseServices<Author>;

    /// <inheritdoc />  
    public class AuthorServices(IApplicationDbContext dbContext) : BaseServices<Author>(dbContext), IAuthorServices;
}