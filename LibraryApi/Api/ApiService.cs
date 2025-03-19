using LibraryApi.Api.Authors;

namespace LibraryApi.Api{
    public static class ApiService
    {
        public static IApplicationBuilder AddApiEndpoints(this WebApplication application)
        {
            AuthorEndpoints.Register(application);
            return application;
        }
    }
}