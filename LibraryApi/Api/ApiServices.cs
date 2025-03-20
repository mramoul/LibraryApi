using LibraryApi.Api.Authors;

namespace LibraryApi.Api{
    public static class ApiServices
    {
        public static IApplicationBuilder AddApiEndpoints(this WebApplication application)
        {
            AuthorEndpoints.Register(application);
            return application;
        }
    }
}