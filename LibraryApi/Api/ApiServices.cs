using LibraryApi.Api.Authors;

namespace LibraryApi.Api
{
    /// <summary>
    /// This class provides an extension method to register API endpoints in a web application.
    //  It ensures that specific API routes are added during application startup, simplifying endpoint management.
    /// </summary>
    public static class ApiServices
    {
        public static IApplicationBuilder AddApiEndpoints(this WebApplication application)
        {
            AuthorEndpoints.Register(application);
            return application;
        }
    }
}