using LibraryApi.Domain.Entities;
using LibraryApi.Infrastructure.DataBaseContext;

namespace LibraryApi.Application.Services.Authors
{
    public interface IAuthorServices : IBaseServices<Author>;

    public class AuthorServices(IApplicationDbContext dbContext) : BaseServices<Author>(dbContext), IAuthorServices;
}