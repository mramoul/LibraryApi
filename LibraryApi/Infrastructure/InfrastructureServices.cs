using LibraryApi.Infrastructure.DataBaseContext;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Infrastructure
{
    /// <summary>
    /// This class provides an extension method to register the infrastructure related services in the web application.
    //  It ensures that specific Infrastructure DI are added during application startup, simplifying infrastructure management.
    /// </summary>
    public static class InfrastructureServices
    {
        public static WebApplicationBuilder AddInfrastructureServices(this WebApplicationBuilder builder)
        {
            AddDbContext(builder);
            AddSwagger(builder);
            
            return builder;
        }

        private static void AddDbContext(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
        }

        private static void AddSwagger(WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
        }
    }
}